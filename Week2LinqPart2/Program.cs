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
 * User: Nityan Khanna
 * Date: 2019-1-18
 */
using System;
using System.Linq;
using System.Net.Sockets;

namespace Week2LinqPart2
{
	class Program
	{
		static void Main(string[] args)
		{
			var content = "the quick brown fox jumps over the lazy dog";

			// define the query
			// Split(new char[] { ' ', '  ', });
			var query = from s in content.Split(' ')
						where s.Contains("e")
						select s;

			// execute the query
			foreach (var item in query)
			{
				Console.WriteLine(item);
			}
						
			Console.ReadKey();
		}
	}
}
