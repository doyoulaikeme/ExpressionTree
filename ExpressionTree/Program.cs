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

            ////声明参数i
            //ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "i");
            ////声明常量
            //ConstantExpression constant = Expression.Constant(1, typeof(int));
            ////声明运算方法，拼装.
            //BinaryExpression binaryAdd = Expression.Add(parameterExpression, constant);
            ////调用Lambda方法
            //Expression<Func<int, int>> expression = Expression.Lambda<Func<int, int>>(binaryAdd, new ParameterExpression[] { parameterExpression });
            ////编译成委托
            //var func = expression.Compile();
            ////执行
            //var result = func.Invoke(1);

            //Console.WriteLine("i+1拼装lambda执行结果为：{0}", result);



            //测试用例
            //Expression<Func<Student, bool>> exp = s => s.Id > 100 && s.Name.StartsWith("doyou") && s.Account.Length > 2 && s.State == 1;

            //ParameterExpression parameterExpression = Expression.Parameter(typeof(Student), "s");

            //ConstantExpression constant = Expression.Constant(1, typeof(int));
            //MemberExpression state = Expression.Property(parameterExpression, typeof(Student).GetProperty("State"));
            //BinaryExpression stateEqual = Expression.Equal(state, constant);


            //ConstantExpression constant1 = Expression.Constant(1, typeof(int));
            //MemberExpression account = Expression.Property(parameterExpression, typeof(Student).GetProperty("Account"));
            //MemberExpression length = Expression.Property(account, typeof(string).GetProperty("Length"));
            //BinaryExpression accountExp = Expression.GreaterThan(length, constant1);


            //ConstantExpression constant2 = Expression.Constant("doyou", typeof(string));
            //MemberExpression name = Expression.Property(parameterExpression, typeof(Student).GetProperty("Name"));

            //MethodCallExpression nameExp = Expression.Call(name, typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) }), new Expression[] { constant2 });


            //ConstantExpression constant3 = Expression.Constant(100, typeof(int));
            //MemberExpression id = Expression.Property(parameterExpression, typeof(Student).GetProperty("Id"));
            //BinaryExpression idExp = Expression.GreaterThan(id, constant3);


            //Expression<Func<Student, bool>> expression = Expression.Lambda<Func<Student, bool>>(
            //    Expression.AndAlso(
            //        Expression.AndAlso(
            //            Expression.AndAlso(idExp, nameExp), accountExp)
            //    , stateEqual)
            //    , new ParameterExpression[] {
            //    parameterExpression
            //    });

            //var student = new Student()
            //{
            //    Id = 123,
            //    Account = "Admin",
            //    Name = "doyoulaikeme",
            //    State = 1

            //};

            //var studentDTO = new StudentDTO()
            //{
            //    Id = 123,
            //    Account = "Admin",
            //    Name = "laikeme",
            //    State = 1

            //};

            ////转化类型传值
            //Func<StudentDTO, Student> _func = s => new Student
            //{
            //    State = s.State,
            //    Account = s.Account,
            //    Id = s.Id,
            //    Name = s.Name
            //};
            //var student1 = _func.Invoke(studentDTO);

            //var exp = expression.Compile();
            //var result = exp.Invoke(student);
            //var result1 = exp.Invoke(student1);
            //Console.WriteLine("拼装结果为： \n exp.Invoke(student)：{0} \n exp.Invoke(student1)：{1}", result, result1);






            #endregion

            #region 自动转换类属性
            //var studentDTO = new StudentDTO()
            //{
            //    Id = 123,
            //    Account = "Admin",
            //    Name = "laikeme",
            //    State = 1

            //};
            //Student dto = ExpressionGenericMapper<StudentDTO, Student>.Trans(studentDTO);

            //Console.WriteLine(dto.Name);

            #endregion

            #region 查看表达式树拼装内部结构

            //lambda表达式解析成sql的where，
            //理解二叉树结构+关联
            Expression<Func<Student, bool>> exp = i => i.Id > 1 && i.State == 1 && i.Account.StartsWith("doyou");
            CustomVisitor visitor = new CustomVisitor();
            visitor.Visit(exp);
            Console.WriteLine(visitor.GetWhere());
            #endregion
            Console.ReadKey();

        }
    }
}
