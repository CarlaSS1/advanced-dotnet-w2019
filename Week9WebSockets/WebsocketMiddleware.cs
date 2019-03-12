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
 * User: khannan
 * Date: 2019-3-12
 */
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Week9WebSockets
{
	/// <summary>
	/// Represents a web socket middleware.
	/// </summary>
	public class WebSocketMiddleware
	{
		/// <summary>
		/// The request delegate.
		/// </summary>
		private RequestDelegate next;

		/// <summary>
		/// Initializes a new instance of the <see cref="WebSocketMiddleware"/> class.
		/// </summary>
		/// <param name="next">The next.</param>
		public WebSocketMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task InvokeAsync()
		{
			// TODO: implement
		}

		private async Task Echo(HttpContext context, WebSocket webSocket)
		{
			// TODO: implement
		}
	}
}
