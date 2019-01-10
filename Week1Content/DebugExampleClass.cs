using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Content
{
	public class DebugExampleClass
	{
		public DebugExampleClass()
		{
			
		}

		public string MyPropertyOne { get; set; }

		public string MyPropertyTwo { get; set; }


		public void DoWork()
		{
			Console.WriteLine(this.MyPropertyOne);
			Console.WriteLine(this.MyPropertyTwo);

			this.PrintUntil(1);
		}

		public void PrintUntil(int number)
		{
			for (int i = 0; i < number; i++)
			{
				Console.WriteLine(i);
			}
		}
	}
}
