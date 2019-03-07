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
 * Date: 2019-3-3
 */

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Week8KestrelWebServer.Model;
using Week8KestrelWebServer.Services;

namespace Week8KestrelWebServer.Handlers
{
	/// <summary>
	/// Represents a person handler.
	/// </summary>
	public class PersonHandler
	{
		/// <summary>
		/// The logger.
		/// </summary>
		private readonly ILogger<PersonHandler> logger;

		/// <summary>
		/// The person service.
		/// </summary>
		private static IPersonService _personService;

		/// <summary>
		/// Initializes a new instance of the <see cref="PersonHandler" /> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		/// <param name="personService">The person service.</param>
		public PersonHandler(ILogger<PersonHandler> logger, IPersonService personService)
		{
			this.logger = logger;
			_personService = personService;
		}

		/// <summary>
		/// Handles the person.
		/// </summary>
		/// <param name="app">The application.</param>
		public static void HandlePerson(IApplicationBuilder app)
		{
			app.Run(async context =>
			{
				//switch (context.Request.Method?.ToUpperInvariant())
				//{
				//	case "GET":
				//		await HandleGet(context);
				//		break;
				//	case "POST":
				//		await HandlePost(context);
				//		break;
				//	default:
				//		context.Response.ContentType = "text/plain";
				//		context.Response.StatusCode = 405; // method not allowed status code
				//		await context.Response.WriteAsync("method not allowed");
				//		break;
				//}
			});
		}

		// handle all of our GET requests
		public static void HandleGet(IApplicationBuilder app)
		{
			app.Run(async context =>
			{
				var personService = new PersonService();
				// attempt to retrieve the name parameter from our query string
				context.Request.Query.TryGetValue("name", out StringValues values);

				// set the name
				var name = values.FirstOrDefault();

				// query the database for our person with a name of the name provided in the GET request query string
				var results = await personService.QueryPersonAsync(
					c => c.FirstName.ToLowerInvariant() == name.ToLowerInvariant()
						|| c.LastName.ToLowerInvariant() == name.ToLowerInvariant());

				// serialize the results returned, and write the result to the response

				var serializer = new XmlSerializer(typeof(PersonViewModel));

				var memoryStream = new MemoryStream();

				serializer.Serialize(memoryStream, results);

				// set the content type
				context.Response.ContentType = "application/xml";

				// writing the response to the client
				await context.Response.WriteAsync(Encoding.UTF8.GetString(memoryStream.ToArray()));

				// no other code, except for maybe logging would
				// be written after you write the response to the client
			});
		}

		// handle all of our POST requests
		public static async Task HandlePost(HttpContext context)
		{

		}

	}
}