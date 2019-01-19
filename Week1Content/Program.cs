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
 * Date: 2019-1-6
 */
using System;

namespace Week1Content
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
		public static void Main(string[] args)
		{
			var myAssemblyClass = new MyAssemblyClass();

			myAssemblyClass.PrintAssemblyInfo();

			string s; // cannot assign a breakpoint here, since no code is being executed

			// create a new instance of our debug example class
			var debugExampleClass = new DebugExampleClass();

			// set our properties of our new class
			debugExampleClass.MyPropertyOne = "property one";
			debugExampleClass.MyPropertyTwo = "property two";

			// call our 'DoWork' method on our new class
			debugExampleClass.DoWork();

			// call our 'PrintUntil' method on our new class
			debugExampleClass.PrintUntil(10);

			Console.ReadKey();
		}
	}
}
