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
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Week8KestrelWebServer.Middleware
{
	/// <summary>
	/// Represents a request log middleware.
	/// </summary>
	public class RequestLogMiddleware
	{
		/// <summary>
		/// The next middleware in the application pipeline.
		/// </summary>
		private readonly RequestDelegate next;

		/// <summary>
		/// Initializes a new instance of the <see cref="RequestLogMiddleware"/> class.
		/// </summary>
		/// <param name="next">The next.</param>
		public RequestLogMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		/// <summary>
		/// Invokes the middleware asynchronously.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns>Returns a task.</returns>
		public async Task InvokeAsync(HttpContext context)
		{

			try
			{
				// TODO: log request data, await next
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
