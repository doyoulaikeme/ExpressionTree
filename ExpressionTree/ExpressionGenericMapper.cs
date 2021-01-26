using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    public class ExpressionGenericMapper<TIn, TOut>
    {
        private static Func<TIn, TOut> _Func = null;

        static ExpressionGenericMapper()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");

            List<MemberBinding> memberBindings = new List<MemberBinding>();

            foreach (var item in typeof(TOut).GetProperties())
            {
                MemberExpression param = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                MemberBinding member = Expression.Bind(item, param);
                memberBindings.Add(member);
            }

            foreach (var item in typeof(TOut).GetFields())
            {

                MemberExpression param = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                MemberBinding member = Expression.Bind(item, param);
                memberBindings.Add(member);
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindings.ToArray());

            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });

            _Func = lambda.Compile();
        }

        public static TOut Trans(TIn t)
        {
            return _Func(t);
        }
    }
}
