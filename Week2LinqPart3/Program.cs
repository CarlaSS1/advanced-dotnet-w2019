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
