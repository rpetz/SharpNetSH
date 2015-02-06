using Ignite.SharpNetSH.Test.Spike;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ignite.SharpNetSH.Test
{
	[TestClass]
	public class ShowActionTests
	{
		[TestMethod]
		public void VerifyCacheStateOutput()
		{
			var result = new NetSH(new CommandLineHarness(false)).Http.Show.SSLCert("0.0.0.0:9388");

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
		public void VerifyServiceStateOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Show.ServiceState(View.ServiceState);
			Assert.AreEqual("netsh http show servicestate view=servicestate", harness.Value);

			new NetSH(harness).Http.Show.ServiceState(View.ServiceState, false);
			Assert.AreEqual("netsh http show servicestate view=servicestate verbose=no", harness.Value);

			new NetSH(harness).Http.Show.ServiceState(View.ServiceState, true);
			Assert.AreEqual("netsh http show servicestate view=servicestate verbose=yes", harness.Value);

			new NetSH(harness).Http.Show.ServiceState(View.Session);
			Assert.AreEqual("netsh http show servicestate view=session", harness.Value);

			new NetSH(harness).Http.Show.ServiceState(View.Session, false);
			Assert.AreEqual("netsh http show servicestate view=session verbose=no", harness.Value);

			new NetSH(harness).Http.Show.ServiceState(View.Session, true);
			Assert.AreEqual("netsh http show servicestate view=session verbose=yes", harness.Value);

			new NetSH(harness).Http.Show.ServiceState(null, false);
			Assert.AreEqual("netsh http show servicestate verbose=no", harness.Value);

			new NetSH(harness).Http.Show.ServiceState(null, true);
			Assert.AreEqual("netsh http show servicestate verbose=yes", harness.Value);

			new NetSH(harness).Http.Show.ServiceState();
			Assert.AreEqual("netsh http show servicestate", harness.Value);
		}

		[TestMethod]
		public void VerifySSLCertOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Show.SSLCert();
			Assert.AreEqual("netsh http show sslcert", harness.Value);

			new NetSH(harness).Http.Show.SSLCert("testipport");
			Assert.AreEqual("netsh http show sslcert ipport=testipport", harness.Value);
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