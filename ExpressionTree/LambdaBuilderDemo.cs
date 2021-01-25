using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    /// <summary>
    /// 可通过反编译工具查看lambda语法糖具体生成源码
    /// </summary>
    public class LambdaBuilderDemo
    {

        public void Show()
        {
            Expression<Func<Student, bool>> exp = s => s.Id > 100;

        }
    }
}
