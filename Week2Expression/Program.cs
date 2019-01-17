using System;
using System.Linq.Expressions;

namespace Week2Expression
{
	class Program
	{
		static void Main(string[] args)
		{
			// define our function
			Func<int, bool> greaterThanFive = x => x > 5;

			// defines our expression of a function
			// the expression is a description/pointer to our function code
			Expression<Func<int, bool>> greaterThanFiveExpression = y => y > 5;

			// invoke our function
			var result = greaterThanFive(5);

			// compile and invoke our expression
			var result2 = greaterThanFiveExpression.Compile().Invoke(5);

			Console.WriteLine(result);
			Console.WriteLine(result2);

			Console.ReadKey();

		}
	}
}
