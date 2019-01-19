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
