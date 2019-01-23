/*
 * Copyright 2016-2019 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: Nityan Khanna
 * Date: 2019-1-18
 */
using System;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Week3ExpressionTrees
{
	public class Program
	{
		private static void Main(string[] args)
		{
			// declare and initialize and constant expression with the value of 100
			var constantExpression = Expression.Constant(100);

			// declare and initialize and constant expression with the value of 105
			var constantExpression2 = Expression.Constant(105);

			// declare and initialize and equals expression
			// where we combine the two constant expressions together to create a resulting expression
			var equalsExpression = Expression.Equal(constantExpression, constantExpression2);

			// using the equals expression, we want to be able to invoke our expression
			// therefore we need to convert our equals expression into a lambda expression
			// and compile the lambda expression in order to invoke it
			var lambdaExpression = Expression.Lambda(equalsExpression).Compile();

			// the above statement and the below statement, yield the same result
			Expression<Func<int, int, bool>> expression = (x, y) => x == y;

			// invokes our lambda expression, without any parameters
			var result = lambdaExpression.DynamicInvoke();

			Console.WriteLine($"Result is: {result}");

			Console.ReadKey();
		}
	}
}
