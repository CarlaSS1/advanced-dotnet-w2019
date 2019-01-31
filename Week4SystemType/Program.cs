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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Week4SystemType
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
			// this will not work, because type is an abstract class
			// Type type = new Type();

			var s = "hello";

			// retrieve the type information from the instance of our string "s"
			Type type = s.GetType();
			
			// print the string type information
			PrintTypeInfo(type);

			int i = 5;
			// reassign type to an integer
			type = i.GetType();

			// print the integer type information
			PrintTypeInfo(type);

			// print the type information
			Console.WriteLine($"Type information about: {typeof(int)}");

			// print the type information about the IEnumerable interface
			Console.WriteLine($"Type information about: {typeof(IEnumerable)}");

			Console.WriteLine($"Type information about: {typeof(object)}");

			// this will not work, because the typeof operator can only accept types, not instances of types
			//Console.WriteLine($"Type information about: {typeof(new object())}");

			object o = new object();

			// the GetType method returns the "type object" for an instance of given type
			type = o.GetType();

			// the typeof operator also returns the "type object" for a given type
			Console.WriteLine($"Type information about: {typeof(object)}");

			Console.Write(Environment.NewLine);
			Console.WriteLine("classes");

			// print out all the types that are class in the given assembly
			foreach (var t in typeof(Program).Assembly.DefinedTypes.Where(c => c.IsClass))
			{
				Console.WriteLine(t);
			}

			Console.Write(Environment.NewLine);
			Console.WriteLine("all types");

			// print out all the types in the assembly
			foreach (var t in typeof(Program).Assembly.DefinedTypes)
			{
				Console.WriteLine(t);
			}

			Console.Write(Environment.NewLine);
			Console.WriteLine("generic types");

			// print out all the generic types in the assembly
			foreach (var t in typeof(Program).Assembly.DefinedTypes.Where(c => c.IsGenericType))
			{
				Console.WriteLine(t);
			}

			Console.Write(Environment.NewLine);
			Console.WriteLine("interfaces");

			// print out all the interfaces in the assembly
			foreach (var t in typeof(Program).Assembly.DefinedTypes.Where(c => c.IsInterface))
			{
				Console.WriteLine(t);
			}

			var list = new List<MyClass>();
			var list2 = new List<string>();
			var list3 = new List<int>();
			var list4 = new List<object>();

			Console.ReadKey();
		}

		private static void PrintTypeInfo(Type type)
		{
			// print the type information
			Console.WriteLine($"Type information about: {type}");

			// prints true if the type is abstract
			Console.WriteLine($"Is the type abstract: {type.IsAbstract}");

			// prints true if the type is a class
			Console.WriteLine($"Is the type a class: {type.IsClass}");

			// prints true if the type is an interface
			Console.WriteLine($"Is the type an interface: {type.IsInterface}");
		}

	}
}
