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

			var tests = new[]
			{
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) true, (bool?) false, (bool?) true, (bool?) false, (bool?) true},
				new object[] {"testipport", null, "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", null, "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", null, "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", null, (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", null, (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), null, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, null, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, null, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, null, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, null, (bool?) true, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, null, (bool?) false},
				new object[] {"testipport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, null}
			};

			foreach (var values in tests)
			{
				var nullValueIndex = values.ToList().IndexOf(null);

				new NetSH(harness).Http.Add.SSLCert(ipPort:										(string)values[0],
													certHash:									(string)values[1],
													certStoreName:								(string)values[2],
													sslCtlIdentifier:							(string)values[3],
													sslCtlStoreName:							(string)values[4],
													appId:										(Guid?) values[5],
													revocationFreshnessTime:					(uint?) values[6],
													urlRetrievalTimeout:						(uint?) values[7],
													verifyClientCertRevocation:					(bool?) values[8],
													verifyRevocationWithCachedClientCertOnly:	(bool?) values[9],
													usageCheck:									(bool?) values[10],
													dsMapperUsage:								(bool?) values[11],
													clientCertNegotation:						(bool?) values[12]);

				var value = harness.Value;
				var parameters = typeof (AddAction).GetMethod("SSLCert").GetParameters();
				var i = 0;
				parameters.ToList().ForEach(x =>
				{

					var type = x.ParameterType;
					var name = x.Name.ToLower();

					if (i == nullValueIndex)
					{
						Assert.IsTrue(!value.Contains(name + "="));
						i++;
						return;
					}

					if (type == typeof (string))
					{
						Assert.IsTrue(value.Contains(name + "=" + "test" + name));
					}
					else if (type == typeof (Guid))
					{
						Assert.IsTrue(value.Contains(name + "={11111111-1111-1111-1111-111111111111}"));
					}
					else if (type == typeof (bool))
					{
						Assert.IsTrue(value.Contains(name + "=enabled") || value.Contains(name + "=disabled"));
					}
					i++;
				});
			}
		}

		[TestMethod]
		public void VerifySSLCertOutputOld()
		{
			var harness = new StringHarness();

			new NetSH(harness).Http.Add.SSLCert(ipPort: "testipport",
				certHash: "testcerthash",
				certStoreName: "testcertstorename",
				sslCtlIdentifier: "testsslctlidentifier",
				sslCtlStoreName: "testsslctlstorename",
				appId: new Guid("11111111-1111-1111-1111-111111111111"),
				revocationFreshnessTime: 1,
				urlRetrievalTimeout: 1,
				verifyClientCertRevocation: false,
				verifyRevocationWithCachedClientCertOnly: true,
				usageCheck: false,
				dsMapperUsage: true,
				clientCertNegotation: false);

			var value = harness.Value;
			var parameters = typeof(AddAction).GetMethod("SSLCert").GetParameters();
			parameters.ToList().ForEach(x =>
			{
				var type = x.ParameterType;
				var name = x.Name.ToLower();
				if (type == typeof(string))
				{
					Assert.IsTrue(value.Contains(name + "=" + "test" + name));
				}
				else if (type == typeof(Guid))
				{
					Assert.IsTrue(value.Contains(name + "={11111111-1111-1111-1111-111111111111}"));
				}
				else if (type == typeof(bool))
				{
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

			netsh.Http.Add.UrlAcl("testurl", "testuser", null, true);
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser delegate=yes", harness.Value);

			netsh.Http.Add.UrlAcl("testurl", "testuser", null, false);
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser delegate=no", harness.Value);

			netsh.Http.Add.UrlAcl("testurl", "testuser", true);
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser listen=yes", harness.Value);

			netsh.Http.Add.UrlAcl("testurl", "testuser", false);
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser listen=no", harness.Value);

			netsh.Http.Add.UrlAcl("testurl", "testuser", "testsddl");
			Assert.AreEqual("netsh http add urlacl url=testurl user=testuser sddl=testsddl", harness.Value);
		}
	}
}