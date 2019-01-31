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

namespace Week4ConstructorInfo
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
			// declare our constructor info variable
			ConstructorInfo[] constructors;

			// the ConstructorInfo class contains information and
			// metadata about constructors for classes

			// retrieve all the public and instance constructors on the class "MyClass"
			// 
			// using BindingFlags of public and instance
			// allows us to only retrieve all the public and instance constructors
			constructors = typeof(MyClass).GetConstructors(BindingFlags.Public | BindingFlags.Instance);

			// print out the constructor information for each constructor in the class "MyClass"
			foreach (var constructorInfo in constructors)
			{
				Console.WriteLine($"Constructor info: {constructorInfo}");
			}

			foreach (var constructorInfo in constructors)
			{
				// if there are any parameters
				// we need to supply those parameters when invoking the constructor
				if (constructorInfo.GetParameters().Any())
				{
					var c = (MyClass)constructorInfo.Invoke(new object[] {"this value was supplied using the parameterized constructor"});

					Console.WriteLine(c.Value);
				}
				else
				{
					// invoke the constructor that has no parameters
					// cast the return value of the invoke method to type MyClass
					// because by default the invoke method returns type of object
					MyClass c = (MyClass)constructorInfo.Invoke(null);

					// set the value of value
					c.Value = "testing value";

					// print the value
					Console.WriteLine(c.Value);
				}
			}

			// retrieve all the public only constructors from the class DerivedClass
			constructors = typeof(DerivedClass).GetConstructors();

			// print the public constructor info
			foreach (var constructorInfo in constructors)
			{
				Console.WriteLine($"Public Constructor info: {constructorInfo}");
			}

			Console.Write(Environment.NewLine);

			// retrieve all the static non public constructors from the the class DerivedClass
			constructors = typeof(DerivedClass).GetConstructors(BindingFlags.NonPublic | BindingFlags.Static);

			// print the static constructor info
			foreach (var constructorInfo in constructors)
			{
				Console.WriteLine($"Static Constructor info: {constructorInfo}");
			}

			Console.ReadKey();
		}
	}

	public class MyClass
	{
		public MyClass()
		{
			
		}

		public MyClass(string value)
		{
			this.Value = value;
		}

		public string Value { get; set; }
	}

	public class DerivedClass : MyClass
	{
		static DerivedClass()
		{

		}

		public DerivedClass()
		{
			
		}

		public DerivedClass(string derivedValue)
		{
			this.DerivedValue = derivedValue;
		}

		public DerivedClass(string value, string derivedValue) : base(value)
		{
			this.DerivedValue = derivedValue;
		}

		public string DerivedValue { get; set; }
	}

	public interface MyInterface
	{

	}

	public interface DerivedInterface : MyInterface
	{

	}

}
