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
 * Date: 2019-2-23
 */
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Week7AsyncDatabaseAccess.Data;
using Week7AsyncDatabaseAccess.Data.Model;
using Week7AsyncDatabaseAccess.Data.ViewModel;

namespace Week7AsyncDatabaseAccess.Services
{
	/// <summary>
	/// Represents a person service.
	/// </summary>
	/// <seealso cref="Week7AsyncDatabaseAccess.Services.IPersonService" />
	public class PersonService :  IPersonService
	{
		/// <summary>
		/// The context.
		/// </summary>
		private readonly ApplicationDbContext context;

		/// <summary>
		/// Initializes a new instance of the <see cref="PersonService" /> class.
		/// </summary>
		public PersonService(ApplicationDbContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Creates a person asynchronously.
		/// </summary>
		/// <param name="firstName">The first name.</param>
		/// <param name="lastName">The last name.</param>
		/// <returns>Returns a task.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public Task<PersonViewModel> CreatePersonAsync(string firstName, string lastName)
		{
			// TODO: add task
			// TODO: save task
			throw new NotImplementedException();
		}

		/// <summary>
		/// Queries for a person asynchronously.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <returns>Returns a list of persons which match the given predicate.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public Task<List<PersonViewModel>> QueryPersonAsync(Expression<Func<Person, bool>> expression)
		{
			// TODO: to list task
			throw new NotImplementedException();
		}
	}
}
