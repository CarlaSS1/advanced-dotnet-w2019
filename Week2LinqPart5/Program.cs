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
using System.Linq;

namespace Week2LinqPart5
{
	class Program
	{
		static void Main(string[] args)
		{
			var persons = new List<Person>
			{
				new Person("Nityan", "Khanna", new DateTime(1970, 01, 01)),
				new Person("Bob", "Smith", new DateTime(1980, 02, 10)),
				new Person("Paul", "Brown", new DateTime(1990, 08, 15)),
				new Person("Mo", "Ibrahim", new DateTime(1981, 06, 12)),
			};

			
			// PURE LINQ
			var query = from p in persons where p.DateOfBirth.Year < 2001 select p;

			// LINQ USING LAMBDA EXPRESSIONS
			// 'Where' filters a given list based on a boolean condition
			var results = persons.Where(x => x.DateOfBirth.Year < 1980);

			Func<Person, bool> condition = x => x.DateOfBirth.Year < 1980;
			var results2 = persons.Where(x => condition(x));

			// 'Select' projects the results of a given list into a new sequence
			// return all of the last names of persons whose first name start with 'M'
			// 'lastNames' is of type IEnumerable<string>
			var lastNames = persons.Where(x => x.FirstName.StartsWith("M"))
			                      .Select(c => c.LastName);

			// only retrieve the first 10 results
			var results4 = lastNames.Take(10);

			// only retrieve all the persons where the length of the last name is
			// greater than 5
			var results5 = persons.TakeWhile(x => x.LastName.Length > 5);

			// returns true if at least one element in the sequence matches the condition
			var results6 = persons.Any(c => c.FirstName.Length < 5);

			// returns true if all the elements in the sequence match the condition
			var results7 = persons.All(c => c.FirstName.Length < 5);

			// retrieve the first item in the collection or null if there are no items
			var results8 = persons.FirstOrDefault();

			// retrieve the first item which matches the condition
			var results9 = persons.FirstOrDefault(c => c.FirstName == "Paul");








			Console.ReadKey();
		}
	}
}
