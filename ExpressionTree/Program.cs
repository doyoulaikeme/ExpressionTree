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

            Expression<Func<int, bool>> pression = p => p > 100;

            Expression<Func<int, int, int>> pression2 = (m, n) => m * n + 1 + 2;

            var stuTable = new List<Student>().AsQueryable();

            //通过拼接表达式树条件查询
            Expression<Func<Student, bool>> exp = null;

            if (true)//条件1
            {
                exp = s => s.Id == 1;
            }

            if (true)//条件2
            {
                exp = s => s.Id == 1 && s.Name.StartsWith("test");
            }

            stuTable = stuTable.Where(exp);

            //自动拼装lambda



            Console.ReadKey();

        }
    }
}
