using System;
using System.Linq;
using Ignite.SharpNetSH.Test.Spike;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ignite.SharpNetSH.Test
{
	[TestClass]
	public class AddActionTests
	{
		[TestMethod]
		public void VerifyIpListenOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Add.IPListen("test");
			Assert.AreEqual("netsh http add iplisten address=test", harness.Value);
		}

		[TestMethod]
		public void VerifySSLCertOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Add.SSLCert(ipPort:"testipport",
				certHash:"testcerthash",
				certStoreName:"testcertstorename",
				sslCtlIdentifier:"testsslctlidentifier",
				sslCtlStoreName:"testsslctlstorename",
				appId:new Guid("11111111-1111-1111-1111-111111111111"),
				revocationFreshnessTime:1,
				urlRetrievalTimeout:1,
				verifyClientCertRevocation:false,
				verifyRevocationWithCachedClientCertOnly:true,
				usageCheck:false,
				dsMapperUsage:true,
				clientCertNegotation:false);

			var value = harness.Value;
			var parameters = typeof (AddAction).GetMethod("SSLCert").GetParameters();
			parameters.ToList().ForEach(x => {
				var type = x.ParameterType;
				var name = x.Name.ToLower();
				if (type == typeof(string)) {
					Assert.IsTrue(value.Contains(name + "=" + "test" + name));
				}
				else if (type == typeof (Guid)) {
					Assert.IsTrue(value.Contains(name + "={11111111-1111-1111-1111-111111111111}"));
				}
				else if (type == typeof (bool)) {
					Assert.IsTrue(value.Contains(name + "=enabled") || value.Contains(name + "=disabled"));
				}
			});
		}

		[TestMethod]
		public void VerifyTimeoutOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Add.Timeout(Timeout.HeaderWaitTimeout, 1);
			Assert.AreEqual("netsh http add timeout timeouttype=headerwaittimeout value=1", harness.Value);
			new NetSH(harness).Http.Add.Timeout(Timeout.IdleConnectionTimeout, 1);
			Assert.AreEqual("netsh http add timeout timeouttype=idleconnectiontimeout value=1", harness.Value);
		}

		[TestMethod]
		public void VerifyUrlAclOutput()
		{
			var harness = new StringHarness();
			var netsh = new NetSH(harness);

			netsh.Http.Add.UrlAcl("testurl", "testuser", false, false);
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser listen=no delegate=no", harness.Value);

			netsh.Http.Add.UrlAcl("testurl", "testuser", false, true);
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser listen=no delegate=yes", harness.Value);

			netsh.Http.Add.UrlAcl("testurl", "testuser", true, false);
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser listen=yes delegate=no", harness.Value);

			netsh.Http.Add.UrlAcl("testurl", "testuser", true, true);
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser listen=yes delegate=yes", harness.Value);

			netsh.Http.Add.UrlAcl("testurl", "testuser", "testsddl");
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser sddl=testsddl", harness.Value);
		}
	}
}