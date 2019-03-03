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
using System.Net;
using System.Text;

namespace Week8HttpListener
{
	/// <summary>
	/// Represents the main program.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		private static void Main(string[] args)
		{
			var listener = new HttpListener();

			listener.Prefixes.Add("http://127.0.0.1:21000/demo/");

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Listener starting");

			listener.Start();

			Console.WriteLine("Reading to accept requests on: http://127.0.0.1:21000/demo/");
			Console.ResetColor();

			listener.BeginGetContext(HandleRequest, listener);

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		/// <summary>
		/// Handles the request.
		/// </summary>
		/// <param name="result">The result.</param>
		private static async void HandleRequest(IAsyncResult result)
		{
			var listener = (HttpListener)result.AsyncState;
			var context = listener.EndGetContext(result);

			Console.WriteLine($"Received request from: {context.Request.RemoteEndPoint}");

			var response = SerializeResponse($"hello this is some content, the current time is: {DateTimeOffset.Now:o}");

			var writeResponseTask = context.Response.OutputStream.WriteAsync(response, 0, response.Length);

			context.Response.ContentType = "text/plain;charset=UTF-8";
			context.Response.StatusCode = 200;

			await writeResponseTask;

			context.Response.Close();

			listener.BeginGetContext(HandleRequest, listener);
		}

		/// <summary>
		/// Serializes the response.
		/// </summary>
		/// <param name="content">The content.</param>
		/// <returns>Returns a byte array representing the response.</returns>
		private static byte[] SerializeResponse(string content)
		{
			Console.WriteLine($"Sending response to client: {content}");

			return Encoding.UTF8.GetBytes(content);
		}
	}
}
