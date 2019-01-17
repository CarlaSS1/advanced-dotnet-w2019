using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week2AsyncLambda
{
	class Program
	{
		delegate void MyPrintDelegate(string s);

		static void Main(string[] args)
		{
			// defines our HTTP client
			var client = new HttpClient();

			// define our delegate
			// the 'async' keyword defines a block of code to run asynchronously
			MyPrintDelegate MyPrintDelegate = async (url) =>
			{
				// define our task using the HTTP client
				var task = client.GetAsync(url);

				// run some synchronous code
				Console.WriteLine("test");
				Console.WriteLine("test line 2");

				// suspend the current thread to allow for another thread to execute synchronously
				await task;
				
				// more synchronous code
				Console.WriteLine("hello");
			};

			// the empty brackets represent a parameter-less function

			Task.Run(async () =>
			{
				Task t = client.GetAsync("http://example.com");

				Console.WriteLine("some synchronous code");
				Console.WriteLine("some more synchronous code 2");
				Console.WriteLine("some more synchronous code 3");
				Console.WriteLine("some more synchronous code 4");

				// the suspension of the task
				await t;
			});

			// functions which use out parameters cannot be used inside lambda expression or with the Func<T> class
			//Func<string, int> parseInteger = x => int.TryParse(x, out _);
		}

		public static async Task MyAsyncMethod(string url)
		{
			var client = new HttpClient();

			Task t = client.GetAsync(url);

			DoSomeWork();

			await t;
		}

		public static void DoSomeWork()
		{
			Thread.SpinWait(1000);
		}
	}
}
