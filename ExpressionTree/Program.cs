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
        /// 表达式树
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("***********表达式树******************");

            Expression<Func<int, bool>> pression = p => p > 100;


            Console.ReadKey();

        }
    }
}
