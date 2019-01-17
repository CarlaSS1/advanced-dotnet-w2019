using System;

namespace Week2ExpressionLambdas
{
	class Program
	{
		// define the delegate
		delegate bool IsEqual(int i);

		static void Main(string[] args)
		{
			// implement the delegate
			// 'x' is the parameter to our delegate
			// 'x == 5' is the body of our delegate
			IsEqual result = x => x == 5;

			// invoking the delegate
			result(5);

			// this function invocation is equivalent to the
			// delegate defined above
			Program.IsEqualToFive(5);

			Console.ReadKey();
		}

		public static bool IsEqualToFive(int i)
		{
			return i == 5;
		}
	}
}
