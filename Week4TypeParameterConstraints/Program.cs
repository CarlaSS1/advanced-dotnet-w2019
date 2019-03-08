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
using System.Collections.Generic;

namespace Week4TypeParameterConstraints
{
	public class Program
	{
		static void Main(string[] args)
		{
			//var myClass = new MyClass<MyClass<MyClass<MyClass<int>>>>();
			var myClass = new MyClass<object>();

			var myClass2 = new MyClass<Person>();

			myClass.DoOtherStuff();
			myClass.DoOtherStuff();
			myClass.SayStuff("hello");

			var personManager = new Manager<Person>();

			var employeeManager = new Manager<Employee>();

			//var employeeManager2 = new Manager<object>();





			Console.ReadKey();
		}
	}

	public class MyClass<T> : MyInterface<T> where T : class, new()
	{
		public void DoStuff()
		{
			Console.WriteLine("do stuff");
		}

		public void DoOtherStuff()
		{
			Console.WriteLine("do other stuff");
		}

		public void SayStuff(string content)
		{
			Console.WriteLine($"Saying stuff: {content}");
		}
	}

	// where T : class - indicates that generic parameters of type T can only be a class
	// where T : class, new() - indicates that generic parameter of type T can only be a class with a default constructor
	public interface MyInterface<T> where T : class, new()
	{
		void DoStuff();

		void DoOtherStuff();

		void SayStuff(string content);
	}

	public class Person
	{
		public Person()
		{
			
		}

		public string Name { get; set; }
	}

	public class Manager<T> where T : Person
	{
		private List<T> items = new List<T>();

		public Manager()
		{
			
		}

		public void Add(T item)
		{
			this.items.Add(item);
		}
	}

	public class Employee : Person
	{

	}
}
