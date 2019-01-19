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
 * Date: 2019-1-13
 */
using System;

namespace Week1Content
{
	/// <summary>
	/// Represents a class which wraps assembly information.
	/// </summary>
	public class MyAssemblyClass
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MyAssemblyClass"/> class.
		/// </summary>
		public MyAssemblyClass()
		{
			
		}

		/// <summary>
		/// Prints the assembly information.
		/// </summary>
		public void PrintAssemblyInfo()
		{
			// retrieves the assembly for the current program
			var assembly = typeof(Program).Assembly;

			// where the code exists on disk
			Console.WriteLine(assembly.CodeBase);

			// custom definitions and behaviour which
			//  have been applied to the assembly
			foreach (var assemblyCustomAttribute in assembly.CustomAttributes)
			{
				Console.WriteLine(assemblyCustomAttribute.AttributeType);
			}

			Console.WriteLine("defined types");
			// defined types are all types within an assembly
			foreach (var assemblyDefinedType in assembly.DefinedTypes)
			{
				Console.WriteLine(assemblyDefinedType);
			}

			//Console.WriteLine("exported types");
			// exported types are types that are ONLY PUBLIC
			foreach (var assemblyDefinedType in assembly.ExportedTypes)
			{
				Console.WriteLine(assemblyDefinedType);
			}

			// the full name of the assembly
			Console.WriteLine(assembly.FullName);

			// the location of the assembly on disk
			Console.WriteLine(assembly.Location);
		}
	}
}
