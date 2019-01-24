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

namespace Week3ConstantExpressions
{
	public class Program
	{
		private static void Main(string[] args)
		{
			// declare and initialize a constant expression with the value of "hello"
			var constantExpression = Expression.Constant("hello");

			// declare and initialize a constant expression with the value of 5
			var constantExpression2 = Expression.Constant(3);

			// declare and initialize a constant expression with the value of a Person object instance
			var constantExpression3 = Expression.Constant(new Person());

			Console.ReadKey();
		}
	}

	public class Person
	{
		public string Name { get; set; }
	}
}
