﻿/*
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
 * Date: 2019-3-7
 */
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Week8KestrelWebServer.Client
{
	/// <summary>
	/// Represents the main program.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// The HTTP client.
		/// </summary>
		private static readonly HttpClient client = new HttpClient();

		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		private static async Task Main(string[] args)
		{
			string input;

			do
			{
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Welcome to the person creator...");
				Console.WriteLine("Please see an action to perform below...");
				Console.WriteLine("1 - Create a person");
				Console.WriteLine("2 - Print a list of all persons");
				Console.WriteLine("3 - Exit");
				Console.ResetColor();

				input = Console.ReadLine();

				switch (input)
				{
					case "1":
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("1 has been entered, will now start the create person workflow...");
						// TODO: implement
						break;
					case "2":
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("2 has been entered, will now start the query person workflow...");
						// TODO: implement
						break;
					case "3":
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("3 has been entered, the program will initiate the stop process...");
						break;
					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"Invalid menu entry: {input}, please enter a valid menu entry...");
						break;
				}

				Console.ResetColor();

			} while (input != "3");
		}

		/// <summary>
		/// Creates a person asynchronously.
		/// </summary>
		/// <returns>Returns a task.</returns>
		private static async Task CreatePersonAsync()
		{
			Console.WriteLine("Please enter the details of the person to create...");

			Console.WriteLine("First name:");
			var firstName = Console.ReadLine();

			Console.WriteLine("Last name:");
			var lastName = Console.ReadLine();

			// TODO: implement
		}

		/// <summary>
		/// Queries for a person asynchronously.
		/// </summary>
		/// <returns>Returns a task.</returns>
		private static async Task QueryPersonAsync()
		{
			Console.WriteLine("Please enter the name of a person to find...");

			var name = Console.ReadLine()?.ToLowerInvariant();

			// TODO: implement
		}
	}
}
