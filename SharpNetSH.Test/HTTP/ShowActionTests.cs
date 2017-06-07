using Ignite.SharpNetSH.Test.Spike;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ignite.SharpNetSH.Test.HTTP
{
	[TestClass]
	public class ShowActionTests
	{
		[TestMethod]
		public void VerifyCacheStateOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Show.CacheState("testurl");
			Assert.AreEqual("netsh http show cachestate url=testurl", harness.Value);

			new NetSH(harness).Http.Show.CacheState();
			Assert.AreEqual("netsh http show cachestate", harness.Value);
		}

		[TestMethod]
		public void VerifyIpListenOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Show.IpListen();
			Assert.AreEqual("netsh http show iplisten", harness.Value);
		}

		[TestMethod]
		public void Test()
		{
			var netsh = new NetSH(new CommandLineHarness()).Http.Show.ServiceStateRequestQueueView(true);
		}

		[TestMethod]
		public void VerifyServiceStateOutput()
		{

			var harness = new StringHarness();

			new NetSH(harness).Http.Show.ServiceStateRequestQueueView();
			Assert.AreEqual("netsh http show servicestate view=requestq", harness.Value);

			new NetSH(harness).Http.Show.ServiceStateRequestQueueView(false);
			Assert.AreEqual("netsh http show servicestate view=requestq verbose=no", harness.Value);

			new NetSH(harness).Http.Show.ServiceStateRequestQueueView(true);
			Assert.AreEqual("netsh http show servicestate view=requestq verbose=yes", harness.Value);

			new NetSH(harness).Http.Show.ServiceStateSessionView();
			Assert.AreEqual("netsh http show servicestate view=session", harness.Value);

			new NetSH(harness).Http.Show.ServiceStateSessionView(false);
			Assert.AreEqual("netsh http show servicestate view=session verbose=no", harness.Value);

			new NetSH(harness).Http.Show.ServiceStateSessionView(true);
			Assert.AreEqual("netsh http show servicestate view=session verbose=yes", harness.Value);
		}

		[TestMethod]
		public void VerifySSLCertOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Show.SSLCert();
			Assert.AreEqual("netsh http show sslcert", harness.Value);

			new NetSH(harness).Http.Show.SSLCert(ipPort: "testipport");
			Assert.AreEqual("netsh http show sslcert ipport=testipport", harness.Value);

			new NetSH(harness).Http.Show.SSLCert(hostnamePort: "www.contoso.com:4443");
			Assert.AreEqual("netsh http show sslcert hostnameport=www.contoso.com:4443", harness.Value);
		}

		[TestMethod]
		public void VerifyTimeoutOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Show.Timeout();
			Assert.AreEqual("netsh http show timeout", harness.Value);
		}

		[TestMethod]
		public void VerifyUrlAclOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Show.UrlAcl();
			Assert.AreEqual("netsh http show urlacl", harness.Value);

			new NetSH(harness).Http.Show.UrlAcl("testurl");
			Assert.AreEqual("netsh http show urlacl url=testurl", harness.Value);
		}
	}
}