using System;
using System.Collections.Generic;
using System.Text;

namespace Week2LinqPart4
{
	public class Person
	{
		public Person()
		{
			
		}

		public Person(string firstName, string lastName, DateTime dateOfBirth)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.DateOfBirth = dateOfBirth;
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }
	}
}
