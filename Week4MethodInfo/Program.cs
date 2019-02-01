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

			// retrieves the public and instance methods on the person class
			var methods = typeof(MyClass).GetMethods(BindingFlags.Instance | BindingFlags.Public);

			// loop through the methods in the  person class
			foreach (var methodInfo in methods)
			{
				Console.Write(Environment.NewLine);

				// print the method name
				Console.WriteLine($"method name: {methodInfo.Name}");

				// print the method return type
				Console.WriteLine($"method return type: {methodInfo.ReturnType}");

				// print whether the method is generic
				Console.WriteLine($"method is is generic: {methodInfo.IsGenericMethod}");

				// print whether the method is abstract
				Console.WriteLine($"method is abstract: {methodInfo.IsAbstract}");


				// find the default constructor on the person class
				object instance = typeof(MyClass).GetConstructors().FirstOrDefault(c => !c.GetParameters().Any())?.Invoke(null);

				// invoke the current method on the instance of our class
				// methodInfo represents the current method
				// instance represents the object upon which to execute the method
				// name/null represent the parameter of the method we are invoking
				methodInfo.Invoke(instance, methodInfo.GetParameters().Any() ? new object[] { name } : null);

				Console.Write(Environment.NewLine);
			}

			// find all the types within the current assembly
			// where the type implements the interface ICommonInterface
			// and where the type is a class
			// and where the class is not abstract
			var types = typeof(Program).Assembly.DefinedTypes
			                           .Where(c => typeof(ICommonInterface).IsAssignableFrom(c)
										&& c.IsClass 
										&& !c.IsAbstract);
			foreach (var type in types)
			{
				// find the default constructor of the type
				// and invoke the default constructor
				object instance = type.GetConstructors().FirstOrDefault(c => !c.GetParameters().Any())
				                      ?.Invoke(null);

				// find the methods on our common interface ICommonInterface
				var iCommonInterfaceMethods = typeof(ICommonInterface)
					.GetMethods(BindingFlags.Instance | BindingFlags.Public).ToList();

				// for each method found
				// invoke the method 
				iCommonInterfaceMethods.ForEach((m) =>
				{
					// invoke the current method in the instance of our class
					// m is the method we are going to invoke
					// instance is the object on which we are invoking the method
					m.Invoke(instance, m.GetParameters().Any() ? new object[] {name} : null);
				});
			}

			Console.ReadKey();
		}
	}

	/// <summary>
	/// Represents a demo class.
	/// </summary>
	/// <seealso cref="Week4MethodInfo.ICommonInterface" />
	public class MyClass : ICommonInterface
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MyClass" /> class.
		/// </summary>
		public MyClass()
		{

		}

		/// <summary>
		/// Displays this instance.
		/// </summary>
		public void Display()
		{
			Console.WriteLine("Called the empty display method");
		}

		/// <summary>
		/// Displays the specified information.
		/// </summary>
		/// <param name="info">The information.</param>
		public void Display(string info)
		{
			Console.WriteLine($"Hello, {info}");
		}

		/// <summary>
		/// Does the common things.
		/// </summary>
		public void DoCommonThings()
		{
			Console.WriteLine("doing common things");
		}

		/// <summary>
		/// Says the common things.
		/// </summary>
		/// <param name="phrase">The phrase.</param>
		public void SayCommonThings(string phrase)
		{
			Console.WriteLine("saying common things");
			Console.WriteLine(phrase);
		}
	}

	/// <summary>
	/// Represents a second demo class.
	/// </summary>
	/// <seealso cref="Week4MethodInfo.ICommonInterface" />
	public class MyOtherClass : ICommonInterface
	{
		/// <summary>
		/// Does the common things.
		/// </summary>
		public void DoCommonThings()
		{
			Console.WriteLine("doing common things in our other class");
		}

		/// <summary>
		/// Says the common things.
		/// </summary>
		/// <param name="phrase">The phrase.</param>
		public void SayCommonThings(string phrase)
		{
			Console.WriteLine("saying common things in our other class");
			Console.WriteLine(phrase);
		}
	}

	/// <summary>
	/// Represents a common interface.
	/// </summary>
	public interface ICommonInterface
	{
		/// <summary>
		/// Does the common things.
		/// </summary>
		void DoCommonThings();

		/// <summary>
		/// Says the common things.
		/// </summary>
		/// <param name="phrase">The phrase.</param>
		void SayCommonThings(string phrase);
	}
}
