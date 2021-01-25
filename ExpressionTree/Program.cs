using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class Program
    {
        /// <summary>
        /// 表达式树是一个二叉树数据结构
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("***********表达式树******************");

            #region 基本调用
            //Expression<Func<int, bool>> pression = p => p > 100;

            //Expression<Func<int, int, int>> pression2 = (m, n) => m * n + 1 + 2;

            //var stuTable = new List<Student>().AsQueryable();

            ////通过拼接表达式树条件查询
            //Expression<Func<Student, bool>> exp = null;

            //if (true)//条件1
            //{
            //    exp = s => s.Id == 1;
            //}

            //if (true)//条件2
            //{
            //    exp = s => s.Id == 1 && s.Name.StartsWith("test");
            //}

            //stuTable = stuTable.Where(exp);
            #endregion

            #region 拼装lambda

            //声明参数i
            ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "i");
            //声明常量1
            ConstantExpression constant = Expression.Constant(1, typeof(int));
            //声明运算方法，拼装.
            BinaryExpression binaryAdd = Expression.Add(parameterExpression, constant);
            //调用Lambda方法
            Expression<Func<int, int>> expression = Expression.Lambda<Func<int, int>>(binaryAdd, new ParameterExpression[] { parameterExpression });
            //编译成委托
            var func = expression.Compile();
            //执行
            var result = func.Invoke(1);

            Console.WriteLine("拼装lambda执行结果为：{0}", result);
            #endregion

            Console.ReadKey();

        }
    }
}
