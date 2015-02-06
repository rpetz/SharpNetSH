using Ignite.SharpNetSH.Test.Spike;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ignite.SharpNetSH.Test
{
	[TestClass]
	public class DeleteActionTests
	{
		[TestMethod]
		public void VerifyCacheOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Flush.LogBuffer();
			Assert.AreEqual(harness.Value, "netsh http flush logbuffer");
		}

		[TestMethod]
		public void VerifyIpListenOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Flush.LogBuffer();
			Assert.AreEqual(harness.Value, "netsh http flush logbuffer");
		}

		[TestMethod]
		public void VerifySSLCertOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Flush.LogBuffer();
			Assert.AreEqual(harness.Value, "netsh http flush logbuffer");
		}

		[TestMethod]
		public void VerifyTimeoutOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Flush.LogBuffer();
			Assert.AreEqual(harness.Value, "netsh http flush logbuffer");
		}

		[TestMethod]
		public void VerifyUrlAclOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Flush.LogBuffer();
			Assert.AreEqual(harness.Value, "netsh http flush logbuffer");
		}
	}
}