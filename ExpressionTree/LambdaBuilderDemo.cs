using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    public class LambdaBuilderDemo
    {

        public void Show()
        {
            Expression<Func<Student, bool>> exp = s => s.Id > 100;

        }
    }
}
