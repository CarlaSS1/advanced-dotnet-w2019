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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Week4ReflectionExpressionTrees
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
			// TODO: read the user input for the first name
			// TODO: read the user input for the date of birth

			var persons = new List<Person>
			{
				new Person("Nityan", new DateTime(1982, 01, 01)),
				new Person("Paul", new DateTime(1977, 05, 04)),
				new Person("Mo", new DateTime(1970, 02, 11)),
				new Person("Laura", new DateTime(1986, 12, 12)),
				new Person("Beatrice", new DateTime(1990, 03, 14))
			}.AsQueryable();

			var parameterExpression = Expression.Parameter(typeof(Person), "p");

			var left = Expression.Property(parameterExpression, typeof(Person).GetProperty("Name"));
			var right = Expression.Constant(null); // TODO: fill in with user input

			var equalsExpression = Expression.Equal(left, right);

			var whereCallExpression = Expression.Call(
				typeof(Queryable), 
				"Where", 
				new[] {persons.ElementType},
				persons.Expression,
				Expression.Lambda<Func<Person, bool>>(equalsExpression, parameterExpression));

			var results = persons.Provider.CreateQuery(whereCallExpression);

			foreach (var person in results)
			{
				Console.WriteLine(person);
			}

			Console.WriteLine("Hello World!");
		}
	}
}
