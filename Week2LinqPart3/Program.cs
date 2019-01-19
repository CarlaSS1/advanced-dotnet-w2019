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
 * Date: 2019-1-18
 */
using System;
using System.IO;
using System.Linq;

namespace Week2LinqPart3
{
	class Program
	{
		static void Main(string[] args)
		{
			// get the path of the app data folder
			var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			// create an DirectoryInfo object instance which contains information about the directory
			var directoryInfo = new DirectoryInfo(path);

			// retrieve all the files ending with file extension .txt recursively
			var files = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);

			// using LINQ retrieve the full name of each file
			var query = from f in files
						select f.FullName;

			foreach (var name in query)
			{
				Console.WriteLine(name);
			}

			Console.ReadKey();
		}
	}
}
