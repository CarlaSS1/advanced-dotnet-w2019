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

namespace Week3BinaryExpressions
{
	public class Program
	{
		private static void Main(string[] args)
		{
			var constantExpression = Expression.Constant(50);
			var constantExpression2 = Expression.Constant(5);

			// creates a binary expression that uses the and operator
			// to 'AND' our two constant expressions together
			var binaryExpression = Expression.MakeBinary(ExpressionType.And, constantExpression, constantExpression2);

			// creates an expression that adds the values of
			// two constant expressions together
			var addExpression = Expression.Add(constantExpression, constantExpression2);

			// compile and invokes the lambda expression
			var result = Expression.Lambda(addExpression).Compile().DynamicInvoke();

			// print the result
			Console.WriteLine(result);

			// print the out string representation of our binary expression
			// our output is (50 & 5)
			Console.WriteLine(binaryExpression.ToString());

			// attempt to declare and initialize a constant expression of type integer
			// and assign the value of the constant expression to null
			// this will crash because we cannot assign null to an int
			// the exception will be of type 'ArgumentException', stating that the types do not match
			// var integerExpression = Expression.Constant(null, typeof(int));


			var seven = Expression.Constant(7);
			var six = Expression.Constant(6);

			var multiplicationExpression = Expression.MakeBinary(ExpressionType.Multiply, six, seven);

			Console.ReadKey();
		}
	}
}
