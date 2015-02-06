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
			new NetSH(harness).Http.Delete.Cache("testurl", false);
			Assert.AreEqual("netsh http delete cache url=testurl recursive=no", harness.Value);
			new NetSH(harness).Http.Delete.Cache("testurl", true);
			Assert.AreEqual("netsh http delete cache url=testurl recursive=yes", harness.Value);
			new NetSH(harness).Http.Delete.Cache("testurl");
			Assert.AreEqual("netsh http delete cache url=testurl", harness.Value);
		}

		[TestMethod]
		public void VerifyIpListenOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Delete.IpListen("testaddress");
			Assert.AreEqual("netsh http delete iplisten ipaddress=testaddress", harness.Value);
		}

		[TestMethod]
		public void VerifySSLCertOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Delete.SSLCert("testipport");
			Assert.AreEqual("netsh http delete sslcert ipport=testipport", harness.Value);
		}

		[TestMethod]
		public void VerifyTimeoutOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Delete.Timeout(Timeout.HeaderWaitTimeout);
			Assert.AreEqual("netsh http delete timeout timeouttype=headerwaittimeout", harness.Value);
			
			new NetSH(harness).Http.Delete.Timeout(Timeout.IdleConnectionTimeout);
			Assert.AreEqual("netsh http delete timeout timeouttype=idleconnectiontimeout", harness.Value);
		}

		[TestMethod]
		public void VerifyUrlAclOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Delete.UrlAcl("testurl");
			Assert.AreEqual("netsh http delete urlacl url=testurl", harness.Value);
		}
	}
}