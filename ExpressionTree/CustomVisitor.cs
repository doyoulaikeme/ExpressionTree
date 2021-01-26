using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    /// <summary>
    /// 递归表达式树目录访问
    /// </summary>
    public class CustomVisitor : ExpressionVisitor
    {
        private Stack<string> sqlStr = new Stack<string>();



        public string GetWhere()
        {
            return string.Join(" ", sqlStr);
        }

        //public override Expression Visit(Expression node)
        //{
        //    Console.WriteLine("Visit方法 {0}  {1}", node.NodeType, node.ToString());
        //    return base.Visit(node);
        //}

        //protected override Expression VisitLambda<T>(Expression<T> node)
        //{
        //    Console.WriteLine("VisitLambda方法 {0}  {1}", node.NodeType, node.ToString());
        //    return base.VisitLambda(node);
        //}


        protected override Expression VisitBinary(BinaryExpression node)
        {
            //Console.WriteLine("VisitBinary方法 {0}  {1}", node.NodeType, node.ToString());
            //return base.VisitBinary(node);
            if (node == null) throw new ArgumentNullException("BinaryExpression");
            sqlStr.Push(")");
            Visit(node.Right);
            sqlStr.Push(" " + node.NodeType.ToSqlOperator() + " ");
            Visit(node.Left);
            sqlStr.Push("(");
            return node;

        }

        /// <summary>
        /// 常量表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node == null) throw new ArgumentNullException("ConstantExpression");
            //Console.WriteLine("VisitConstant方法 {0}  {1}", node.NodeType, node.ToString());
            //Console.WriteLine(node.Value);
            //return base.VisitConstant(node);
            sqlStr.Push("'" + node.Value?.ToString() + "'");
            return node;
        }

        //protected override Expression VisitParameter(ParameterExpression node)
        //{
        //    Console.WriteLine("VisitParameter方法 {0}  {1}", node.NodeType, node.ToString());
        //    Console.WriteLine(node.Name);
        //    return base.VisitParameter(node);
        //}

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null) throw new ArgumentNullException("MemberExpression");
            //Console.WriteLine("VisitMember方法 {0}  {1}", node.NodeType, node.ToString());
            //Console.WriteLine(node.Member);

            sqlStr.Push("[" + node.Member.Name + "]");
            return base.VisitMember(node);
        }

        /// <summary>
        /// 方法表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node == null) throw new ArgumentNullException("MethodCallExpression");

            string format;
            switch (node.Method.Name)
            {
                case "StartsWith":
                    format = "({0}) LIKE {1}+'%'";
                    break;
                case "Contains":
                    format = "({0}) LIKE '%'+{1}+'%'";
                    break;
                case "EndsWith":
                    format = "({0}) LIKE '%'+{1}";
                    break;
                default:
                    throw new NotSupportedException(node.NodeType + " is not supported！");

            }
            this.Visit(node.Object);
            this.Visit(node.Arguments[0]);
            var right = sqlStr.Pop();
            var left = sqlStr.Pop();
            sqlStr.Push(string.Format(format, left, right));
            return node;
        }
    }
}
