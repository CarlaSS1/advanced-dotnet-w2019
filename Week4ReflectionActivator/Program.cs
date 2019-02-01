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

namespace Week4ReflectionActivator
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
			// creates an instance of an object using the Activator class
			// the default implementation of the Activator class invokes the default constructor
			var instance = Activator.CreateInstance(typeof(object));

			Console.WriteLine(instance);

			// creates an instance of our person class using the activator class
			// the parameterized constructor is used here, because we are supplying a parameter to the activator class
			var instance2 = Activator.CreateInstance(typeof(Person), "Test name here");

			Console.WriteLine(instance2);

			Console.ReadKey();
		}
	}
}
