using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week1Content;

namespace Week1ContentTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			DebugExampleClass debugExampleClass = new DebugExampleClass();

			Assert.IsNull(debugExampleClass.MyPropertyOne);
		}
	}
}
