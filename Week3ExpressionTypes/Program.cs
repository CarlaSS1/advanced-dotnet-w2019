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

namespace Week3ExpressionTypes
{
	public class Program
	{
		private static void Main(string[] args)
		{
			// declare and initialize our constant expression to a value of 100
			var constantExpression = Expression.Constant(100);

			// create a binary expression, with an expression type of add
			// the left side of our expression is a constant expression with the value of 100
			// the right side of our expression is a constant expression with the value of 5
			// the resulting expression is a binary expression
			var binaryExpression = Expression.MakeBinary(ExpressionType.Add, constantExpression, Expression.Constant(5));

			// convert our binary expression to a lambda expression
			// then compile our lambda expression
			var lambdaExpression = Expression.Lambda(binaryExpression).Compile();

			// invoke our lambda expression
			var result = lambdaExpression.DynamicInvoke();

			// print the result
			Console.WriteLine($"Result is: {result}");

			Console.ReadKey();
		}
	}
}
