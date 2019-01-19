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
 * Date: 2019-1-18
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Week2Content
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
			// AppDomain.CurrentDomain.BaseDirectory yields ${Project Directory}\bin\Debug
			// AppDomain.CurrentDomain.BaseDirectory yields ${Project Directory}\bin\Release
			var dataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Person.xml");

			XElement persons = XElement.Load(dataFile);
			
			// from 'person' -> variable
			// persons -> list or collection
			// select -> retrieves a given object from the list or
			// allows us to project the elements into a new sequence
			// retrieves the first name of each person in the collection
			// when the program reaches this line, the query will not run right away
			var query = from person in persons.Elements()
						select person.Element("FirstName")?.Value;

			// the above query and the below for loop are equivalent

			var firstNames = new List<string>();

			// this code will execute the query right away
			foreach (var person in persons.Elements())
			{
				var firstName = person.Element("FirstName")?.Value;
				firstNames.Add(firstName);

				Console.WriteLine(firstName);
			}

			// the query is executed here
			foreach (var firstName in query)
			{
				Console.WriteLine(firstName);
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}
