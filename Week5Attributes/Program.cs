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
 * Date: 2019-1-31
 */
using System;
using System.Diagnostics;

namespace Week5Attributes
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
			Console.WriteLine("Hello...");
			Console.WriteLine("Enter a command to run, or type help for help, or type exit to exit");

			var exit = false;

			string input;

			do
			{
				input = Console.ReadLine();

				if (input == "exit")
				{
					exit = true;
				}
				else
				{
					// TODO: implement using reflection and attributes
					// to print out information about the command
					// and run the command
				}
			} while (!exit);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Goodbye");
			Console.WriteLine("Press any key to exit...");

			Console.ReadKey();
		}

		//[ActionDescription]
		//[Command]
		private static void Help()
		{
			// print the entire help menu
		}

		//[ActionDescription]
		//[Command]
		private static void Help(string command)
		{
			// print the help menu for a specific command
		}

		//[ActionDescription]
		//[Command]
		private static void Say(string phrase)
		{
			Console.WriteLine(phrase);
		}

		//[ActionDescription]
		//[Command]
		private static void Walk(int distance)
		{
			Console.WriteLine($"Walking: {distance} metres");
		}

		//[ActionDescription]
		//[Command]
		private static void Walk(int distance, int speed)
		{
			Console.WriteLine($"Walking: {distance} metres at speed: {speed} km/h");
		}

		//[ActionDescription]
		//[Command]
		private static void RunNotepad()
		{
			Process.Start("notepad");
		}
	}
}
