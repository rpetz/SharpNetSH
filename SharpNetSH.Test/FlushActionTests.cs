using Ignite.SharpNetSH.Test.Spike;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ignite.SharpNetSH.Test
{
	[TestClass]
	public class FlushActionTests
	{
		[TestMethod]
		public void VerifyLogBufferOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Flush.LogBuffer();
			Assert.AreEqual("netsh http flush logbuffer", harness.Value);
		}
	}
}
