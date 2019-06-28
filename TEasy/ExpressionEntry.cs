﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TEasy
{
    internal class ExpressionEntry : ExpressionVisitor
    {
        [ThreadStatic]
        private static Dictionary<string, object> _parameters = null;
        
        internal static Dictionary<string, object> Parameters
        {
            get
            {
                if(_parameters == null)
                {
                    _parameters = new Dictionary<string, object>();
                }
                return _parameters;
            }
        }

        [ThreadStatic]
        internal static bool? NonParametric = null;

        internal static ISqlAdapter SqlAdapter = new DefaultSqlAdapter();

        private string whereClause = string.Empty;

        public (string,Dictionary<string,object>) GetResult()
        {
            Dictionary<string, object> CloneParameters(Dictionary<string, object> parameters)
            {
                Dictionary<string, object> clonedParameters = new Dictionary<string, object>();
                foreach (var keyvaluePair in parameters)
                {
                    clonedParameters.Add(keyvaluePair.Key, keyvaluePair.Value);
                }
                return clonedParameters;
            }
            var clonePara = CloneParameters(Parameters);
            Parameters.Clear();
            return (whereClause, clonePara);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            whereClause = GetWhereClauseByExpression(node.Body).ToString();
            return node;
        }

        internal static string EnsurePatameter(MemberInfo mi)
        {
            string key = SqlAdapter.GetParameterName(mi);
            int seed = 1;
            while (Parameters.ContainsKey($"@{key}"))
            {
                key = key + seed;
                seed++;
            }
            return key;
        }

        internal static object GetConstantByExpression(Expression expression)
        {
            ConstantExpressionVisitor constantExpressionVisitor = null;
            if (expression is ConstantExpression)
            {
                constantExpressionVisitor = new ConstantExpressionVisitor();
            }
            else if (expression is MemberExpression)
            {
                constantExpressionVisitor = new MemberConstantExpressionVisitor();
            }
            else if (expression is MethodCallExpression)
            {
                constantExpressionVisitor = new MethodConstantExpressionVisitor();
            }
            else if (expression is ConditionalExpression)
            {
                constantExpressionVisitor = new ConditionalConstantExpressionVisitor();
            }
            else if( expression.GetType().Name == "MethodBinaryExpression")
            {
                constantExpressionVisitor = new MethodBinaryConstantExpressionVisitor();
            }
            else
            {
                throw new Exception($"Unknow expression {expression.GetType()}");
            }
            constantExpressionVisitor.Visit(expression);
            return constantExpressionVisitor.Value;
        }

        internal static StringBuilder GetWhereClauseByExpression(Expression expression)
        {
            BaseExpressionVisitor expressionVisitor = null;
            if (expression is BinaryExpression)
            {
                expressionVisitor = new BinaryExpressionVisitor();
            }
            else if (expression is MemberExpression)
            {
                expressionVisitor = new BooleanMemberExpressionVisitor();
            }
            else if (expression is MethodCallExpression)
            {
                expressionVisitor = new MethodCallExpressionVisitor();
            }
            else if (expression is UnaryExpression unaryExpression
                && unaryExpression.Operand is MemberExpression
                && unaryExpression.Type == typeof(bool))
            {
                expressionVisitor = new UnaryBooleanMemberExpressionVisitor();
            }
            else
            {
                throw new NotSupportedException($"Unknow expression {expression.GetType()}");
            }

            expressionVisitor.Visit(expression);
            return expressionVisitor.GetResult();
        }
    }
}
