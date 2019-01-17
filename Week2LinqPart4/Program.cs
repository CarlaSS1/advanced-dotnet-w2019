using System;
using System.Collections.Generic;
using System.Linq;

namespace Week2LinqPart4
{
	class Program
	{
		static void Main(string[] args)
		{
			// initialize our list of persons
			// we are using a collection initializer here to add persons to our list
			var persons = new List<Person>
			{
				new Person("Bob", "Smith", new DateTime(1970, 01, 01)),
				new Person("Mary", "Smith", new DateTime(2005, 01, 01)),
				new Person("Donald", "Trump", new DateTime(1946, 01, 01))
			};

			// define the query
			var query = from p in persons
						where p.DateOfBirth.Year < 2001
						select p;

			// execute the query
			foreach (var person in query)
			{
				Console.WriteLine($"{person.FirstName}, {person.LastName}, {person.DateOfBirth:yyyy-MM-dd}");
			}

			// find all the persons born earlier than 2001
			// and PROJECT the items into a new sequence
			// this new sequence can be an
			//	anonymous object
			//	a different object entirely
			// 
			var projectionQuery = from p in persons
								  where p.DateOfBirth.Year < 2001
								  select new { p.FirstName, p.LastName };

			foreach (var item in projectionQuery)
			{
				Console.WriteLine(item.FirstName);
				Console.WriteLine(item.LastName);
			}


			// calling our extension method as an instance method
			var result = persons.MyExtensionMethod();

			// calling our extension method as a static method
			var result2 = PersonExtensions.MyExtensionMethod(persons);

			Console.ReadKey();
		}
	}
}
