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
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace Week2FuncExpression
{
	class Program
	{
		static void Main(string[] args)
		{
			// define our function
			// an inline function, defined using our Func<T> class
			// 'int' is our datatype for the first parameter of our function
			// 'bool' is the datatype for the return type of our function
			Func<int, bool> myFunction = x => x > 10;

			// invoke our function
			var result = myFunction(100);

			// an inline function with no parameters
			// returns true
			Func<bool> myOtherFunction = () => true;

			// an inline function with 2 parameters
			// calculates the sum of two integers, x and y
			Func<int, int, int> sum = (x, y) => x + y;

			// invoke our sum function
			// and assign the result to a variable called 'resultSum'
			var resultSum = sum(10, 5);

			Func<int, int, int> calculateProduct = (x, y) => x * y;

			// print the result
			Console.WriteLine(result);

			Func<string, string, string> concatenate = (x, y) => $"{x} {y}";

			Console.ReadKey();
		}

		public static int Sum(int x, int y)
		{
			return x + y;
		}

		public static int Divide(int x, int y, Func<int, int, bool> callback)
		{
			var result = callback(x, y);

			return x / y;
		}
	}
}
