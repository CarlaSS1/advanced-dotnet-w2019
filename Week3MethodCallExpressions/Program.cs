﻿/*
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
 * Date: 2019-1-24
 */
using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Week3MethodCallExpressions
{
	public class Program
	{
		private static void Main(string[] args)
		{
			// creates a parameter expression of type string, with the variable name of "s";
			ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "s");

			Console.WriteLine(parameterExpression.Name);
			Console.WriteLine(parameterExpression.NodeType);

			string x = "";

			var parameterExpression2 = Expression.Parameter(x.GetType(), "a");

			//var type = typeof("hello");
			//var myInt = 2;
			//var type2 = typeof(myInt);


			// declare an initialize our method call expression to access the "ToLower" method on the string class
			// we need provide the types of arguments to our method call expression
			// this helps avoid issues where methods are overloaded within a given class or parent class
			MethodCallExpression methodCallExpression = Expression.Call(parameterExpression, typeof(string).GetMethod("ToLower", Type.EmptyTypes));


			Console.ReadKey();
		}
	}
}
