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
