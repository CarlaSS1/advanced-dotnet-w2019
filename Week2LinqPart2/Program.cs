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
