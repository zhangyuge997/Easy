using Easy.Utility.AttributeExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Utility.MappingExt
{
    /// <summary>
    /// 生成表达式目录树  泛型缓存
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class ExpressionMapper<TIn, TOut>//Mapper`2
    {
        private static Func<TIn, TOut> _FUNC = null;
        static ExpressionMapper()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            foreach (var item in typeof(TOut).GetProperties())
            {
                PropertyInfo propertyInfo=   typeof(TIn).GetProperty(item.GetColumn());
                if (propertyInfo != null)
                {
                    MemberExpression property = Expression.Property(parameterExpression, propertyInfo);
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
            }
            foreach (var item in typeof(TOut).GetFields())
            {
                FieldInfo fieldInfo= typeof(TIn).GetField(item.GetColumn());
                if (fieldInfo != null)
                {
                    MemberExpression property = Expression.Field(parameterExpression, fieldInfo);
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
            }
            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[]
            {
                    parameterExpression
            });
            _FUNC = lambda.Compile();
        }
        public static TOut Trans(TIn t)
        {
            return _FUNC(t);
        }
    }
}
