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
 * Date: 2019-1-23
 */
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Week3PropertyExpressions
{
	public class Program
	{
		private static void Main(string[] args)
		{
			// 
			var person = new Person();

			// declare and initialize our property expression
			// we do this by creating a constant expression
			// and setting the value of the constant expression to our object that we want to access
			// we also need to provide the name of the property we are accessing on our object
			var propertyExpression = Expression.Property(Expression.Constant(person), "Name");

			// accesses the Person class
			// retrieves the name member from the person class
			// retrieves the first element in the array
			var memberInfo = typeof(Person).GetMember("Name")[0];

			// declare and initialize our property expression
			// we are accessing the member of the Person class
			// by providing the member information, which is retrieved using reflection
			// and the typeof operator
			var propertyExpression2 = Expression.MakeMemberAccess(Expression.Constant(person), memberInfo);

			// get the member info of the gender field on our person class
			var genderMemberInfo = typeof(Person).GetMember("Gender")[0];

			// declare and initialize our member access
			// to retrieve the gender field from our person class
			var memberExpression = Expression.MakeMemberAccess(Expression.Constant(person), genderMemberInfo);

			// print the property expressions
			Console.WriteLine(propertyExpression.ToString());
			Console.WriteLine(propertyExpression2.ToString());

			// print the member expression
			Console.WriteLine(memberExpression.ToString());

			Console.ReadKey();
		}
	}

	public class Person
	{
		public string Gender = "";

		public event EventHandler myEventHandler;

		public string Name { get; set; }

		public DateTime DateOfBirth { get; set; }
	}
}
