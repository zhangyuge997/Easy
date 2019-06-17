using Easy.Utility;
using Easy.Utility.AttributeExt;
using Easy.Utility.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Easy.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConstantExpression constant = Expression.Constant(1);
            ConstantExpression constant2 = Expression.Constant(2);
            ParameterExpression m = Expression.Parameter(typeof(int), "m");
            ParameterExpression n = Expression.Parameter(typeof(int), "n");
            BinaryExpression binary = Expression.Add(constant, constant2);
            BinaryExpression binary2 = Expression.Multiply(m, n);
            var ex = Expression.Add(binary, binary2);
            var f = Expression.Lambda<Func<int, int, int>>(ex, new ParameterExpression[] { m, n });
            System.Console.WriteLine(f.Compile()(30, 30));


            System.Console.ReadLine();
        }


    }
}

