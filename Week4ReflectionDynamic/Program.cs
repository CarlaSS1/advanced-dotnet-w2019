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
 * Date: 2019-1-31
 */
using System;
using System.Dynamic;

namespace Week4ReflectionDynamic
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
			// dynamic typing is the process of resolving member information at runtime, regardless of type
			// we can do this using the "dynamic" keyword

			// declare and initialize a dynamic object
			// using the ExpandoObject class, we can add members to a type a runtime
			dynamic d = new ExpandoObject();

			// by simply declaring and initializing the value of our property called MyProperty
			// we have effectively added the property MyProperty to our object
			d.MyProperty = "testing value";

			// by simply declaring and initializing an action called MyMethod
			// we have effectively added the method MyMethod to our object
			d.MyMethod = (Action)(() =>
			{
				Console.WriteLine("this is a dynamic action");
			});

			// let's print out the contents of the property
			Console.WriteLine(d.MyProperty);

			// let's invoke our method we just created
			d.MyMethod();

			dynamic d2 = new object();

			// this will compile successfully, however will encounter a runtime error 
			// because object does not contain a property called MyProperty
			// un-comment the below line of code and run the project to see the error
			// d2.MyProperty = "test";

			dynamic d3 = null;

			// this will compile successfully, however an exception of
			// type RuntimeBinderException will be thrown
			// because we cannot perform runtime binding on a null reference, i.e. an object that is null or has not been initialized
			// un-comment the below line of code and run the project to see the error
			//d3.MyMethod = (Action)(() =>
			//{
			//	Console.WriteLine("this is a dynamic action");
			//});

			Console.ReadKey();
		}
	}
}
