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
