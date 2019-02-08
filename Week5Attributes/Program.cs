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
using System.Linq;
using System.Reflection;

namespace Week5Attributes
{
	/// <summary>
	/// Represents the main program.
	/// </summary>
	// apply our custom attribute to our program class
	// note the suffix of attribute is missing, because it is implied
	[MyCustom("my custom value")]
	[MyCustom("my other custom value")]
	[MyCustom("my other custom value 3")]
	[MyCustom("my other custom value 4")]
	[MyCustom("my other custom value 5")]
	public class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		private static void Main(string[] args)
		{
			Console.WriteLine("Printing information about attributes on the program class");

			// retrieve all the attributes of type MyCustomAttribute on the program class
			// and select the values from the retrieved attributes
			var values = typeof(Program).GetCustomAttributes<MyCustomAttribute>().Select(c => c.MyValue);

			// for each value, print the value of the attribute
			foreach (var value in values)
			{
				Console.WriteLine($"Value for custom attribute {value}");
			}

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
					// retrieve all of the static, non public methods from the program class
					var methods = typeof(Program).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);

					// for each method in the program class, find the methods
					// that have the attribute CommandAttribute applied
					// based on the user input command
					// project the new results into the original method as a list
					var method = methods.SelectMany(c => c.GetCustomAttributes<CommandAttribute>()
					                                                .Where(a =>a.Name == input)
					                                                .Select(b => c))
																	.FirstOrDefault();
					if (method == null)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"Method not found for command: {input}");
						Console.ResetColor();
						continue;
					}

					// invoke the appropriate method based on the user input
					method.Invoke(null, method.GetParameters().Any() ? input.Split(' ') : null);
				}
			} while (!exit);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Goodbye");
			Console.WriteLine("Press any key to exit...");

			Console.ReadKey();
		}

		//[ActionDescription]
		[Command("h")]
		[Command("help")]
		[Help("Prints the help menu for all commands. Example usage: 'h' or 'help'")]
		private static void Help()
		{
			// retrieve all the attributes on the methods in the program class with the HelpAttribute applied
			// in our where clause we want to skip this method, otherwise
			// we will encounter a stack overflow exception
			var attributes = typeof(Program).GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
										.Where(c => c.GetCustomAttributes<HelpAttribute>().Any()
										&& c.Name != "Help")
										.SelectMany(c => c.GetCustomAttributes<HelpAttribute>())
										.ToList();

			attributes.ForEach((a) =>
			{
				Console.WriteLine($"Help menu for: {a.Content}");
			});
		}

		//[ActionDescription]
		[Command("h")]
		[Command("help")]
		[Help("Prints the help menu for a single command. Example usage: 'h' 'command' or 'help' 'command'")]
		private static void Help(string command)
		{
			// print the help menu for a specific command
		}

		//[ActionDescription]
		[Command("say")]
		[Help("Says a given phrase. Example usage: 'say' 'phrase'")]
		private static void Say(string phrase)
		{
			Console.WriteLine(phrase);
		}

		//[ActionDescription]
		[Command("w")]
		[Command("walk")]
		[Help("Walks a given distance. Example usage: 'walk' '10'")]
		private static void Walk(int distance)
		{
			Console.WriteLine($"Walking: {distance} metres");
		}

		//[ActionDescription]
		[Command("w")]
		[Command("walk")]
		[Help("Walks a given distance at a given speed. Example usage: 'walk' '10' '15'")]
		private static void Walk(int distance, int speed)
		{
			Console.WriteLine($"Walking: {distance} metres at speed: {speed} km/h");
		}

		//[ActionDescription]
		[Command("notepad")]
		[Help("Runs notepad.exe. Example usage: 'notepad'")]
		private static void RunNotepad()
		{
			Process.Start("notepad");
		}

		[Command("sh")]
		[Command("sayhello")]
		[Help("Says hello. Example usage: 'sh' or 'sayhello'")]
		private static void SayHello()
		{
			Console.WriteLine("hello");
		}
	}
}
