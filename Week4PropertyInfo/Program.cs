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
using System.Reflection;

namespace Week4PropertyInfo
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
			// retrieve all the public and instance properties from our person class
			var properties = typeof(Person).GetProperties(BindingFlags.Instance | BindingFlags.Public);

			// find the default constructor on the person class and invoke it to create an instance of a person
			var instance = typeof(Person).GetConstructor(Type.EmptyTypes).Invoke(null);

			// for each property on the person class
			foreach (var propertyInfo in properties)
			{
				// if the property is of type string
				// set the property value to the value of "test name value"
				if (propertyInfo.PropertyType == typeof(string))
				{
					// instance - refers to the object whose property value will be set, in this case, instance is the instance of our person class
					// the second parameter is the value of the property
					propertyInfo.SetValue(instance, "test name value");
				}
				else if (propertyInfo.PropertyType == typeof(DateTime))
				{
					// instance - refers to the object whose property value will be set, in this case, instance is the instance of our person class
					// the second parameter is the value of the property
					propertyInfo.SetValue(instance, DateTime.Now);
				}
			}

			// print out the instance of our person
			Console.WriteLine(instance);

			Console.ReadKey();
		}
	}
}