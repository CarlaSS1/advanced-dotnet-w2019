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
 * Date: 2019-1-30
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Week4MethodInfo
{
	/// <summary>
	/// Represents the main program.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		private static void Main(string[] args)
		{
			Console.WriteLine("Please enter a name to print: ");

			var name = Console.ReadLine();

			var methods = typeof(Person).GetMethods(BindingFlags.Instance | BindingFlags.Public);

			foreach (var methodInfo in methods)
			{
				Console.Write(Environment.NewLine);

				Console.WriteLine($"method name: {methodInfo.Name}");
				Console.WriteLine($"method return type: {methodInfo.ReturnType}");
				Console.WriteLine($"method is is generic: {methodInfo.IsGenericMethod}");
				Console.WriteLine($"method is abstract: {methodInfo.IsAbstract}");

				var instance = typeof(Person).GetConstructors().FirstOrDefault(c => !c.GetParameters().Any())?.Invoke(null);

				methodInfo.Invoke(instance, methodInfo.GetParameters().Any() ? new object[] { name } : null);

				Console.Write(Environment.NewLine);
			}


			Console.ReadKey();
		}
	}
}
