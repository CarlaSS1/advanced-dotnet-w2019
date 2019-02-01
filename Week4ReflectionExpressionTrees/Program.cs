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
				CreateInstance<Person>(new Dictionary<string, object> {{"Name", "Nityan"}, {"DateOfBirth", new DateTime(1982, 01, 01)}}),
				CreateInstance<Person>(new Dictionary<string, object> {{"Name", "Paul" }, {"DateOfBirth", new DateTime(1977, 05, 14)}}),
				CreateInstance<Person>(new Dictionary<string, object> {{"Name", "Mo" }, {"DateOfBirth", new DateTime(1977, 02, 11)}}),
				CreateInstance<Person>(new Dictionary<string, object> {{"Name", "Laura" }, {"DateOfBirth", new DateTime(1986, 12, 12)}}),
				CreateInstance<Person>(new Dictionary<string, object> {{"Name", "Beatrice" }, {"DateOfBirth", new DateTime(1990, 03, 14)}})
			}.AsQueryable();

			var parameterExpression = Expression.Parameter(typeof(Person), "p");

			var left = Expression.Property(parameterExpression, typeof(Person).GetProperty("Name"));
			var right = Expression.Constant(null); // TODO: fill in with user input

			var equalsExpression = Expression.Equal(left, right);

			var whereCallExpression = Expression.Call(
				typeof(Queryable),
				"Where",
				new[] { persons.ElementType },
				persons.Expression,
				Expression.Lambda<Func<Person, bool>>(equalsExpression, parameterExpression));

			var results = persons.Provider.CreateQuery(whereCallExpression);

			foreach (var person in results)
			{
				Console.WriteLine(person);
			}

			Console.ReadKey();
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <typeparam name="T">The type for which to create an instance.</typeparam>
		/// <param name="properties">The properties.</param>
		/// <returns>T.</returns>
		/// <exception cref="System.InvalidOperationException">
		/// </exception>
		/// <exception cref="System.ArgumentNullException">properties - Value cannot be null</exception>
		/// <exception cref="System.ArgumentException">
		/// Properties must not be empty - properties
		/// or
		/// Properties must contain 2 entries - properties
		/// </exception>
		private static T CreateInstance<T>(Dictionary<string, object> properties) where T : class
		{
			// find the first constructor that has 2 parameters
			var constructorInfo = typeof(T).GetConstructors().FirstOrDefault(c => c.GetParameters().Length == 2);

			if (constructorInfo == null)
			{
				throw new InvalidOperationException($"Unable to locate constructor with 2 parameters on class: {typeof(T).Name}");
			}

			// if the first parameters is not a string and the second parameter is not a date time, throw an exception
			if (constructorInfo.GetParameters()[0].ParameterType != typeof(string) && constructorInfo.GetParameters()[1].ParameterType != typeof(DateTime))
			{
				throw new InvalidOperationException($"Unable to locate constructor with correct parameter order on class: {typeof(T).Name}");
			}

			// if properties is null, throw an exception
			if (properties == null)
			{
				throw new ArgumentNullException(nameof(properties), "Value cannot be null");
			}

			// if properties is empty, throw an exception
			if (!properties.Any())
			{
				throw new ArgumentException("Properties must not be empty", nameof(properties));
			}

			// if there aren't exactly two properties, throw an exception
			if (properties.Count != 2)
			{
				throw new ArgumentException("Properties must contain 2 entries", nameof(properties));
			}

			// create a "NEW" expression to create a new instance of our class
			var newExpression = Expression.New(constructorInfo, Expression.Constant(properties.Values.ToArray()[0]), Expression.Constant(properties.Values.ToArray()[1]));

			// compile and invoke our lambda expression
			return (T)Expression.Lambda<Func<T>>(newExpression).Compile().DynamicInvoke();
		}
	}
}
