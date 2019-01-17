using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Week2LinqPart4
{
	// define our extension class as static
	// our class which defines extension methods, must be static
	public static class PersonExtensions
	{
		// define our first extension method which accepts a parameter of type
		// IEnumerable<Person>
		// the extension method must be static
		// all extension methods must contain a first parameter using the "this" keyword
		public static string MyExtensionMethod(this IEnumerable<Person> source)
		{
			return string.Join(" ", from s in source select s.FirstName);
		}

		// define our second extension method which accepts a parameter of type
		// Person
		// the extension method must be static
		// all extension methods must contain a first parameter using the "this" keyword
		public static string MyOtherExtensionMethod(this Person source)
		{
			return source.FirstName;
		}
	}
}
