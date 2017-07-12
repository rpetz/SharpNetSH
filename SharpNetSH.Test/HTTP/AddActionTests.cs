using System;
using System.Linq;
using Ignite.SharpNetSH.Test.Spike;
using Ignite.SharpNetSH.HTTP;
using Ignite.SharpNetSH.HTTP.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ignite.SharpNetSH.Test.HTTP
{
	[TestClass]
	public class AddActionTests
	{
		[TestMethod]
		public void VerifyIpListenOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Add.IpListen("test");
			Assert.AreEqual("netsh http add iplisten ipaddress=test", harness.Value);
		}

		// ReSharper disable RedundantArgumentName
		[TestMethod]
		public void VerifySSLCertOutput()
		{
			var harness = new StringHarness();

			var tests = new[]
			{
				new object[] {"testipport", null, "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) true, (bool?) false, (bool?) true, (bool?) false, (bool?) true},
				new object[] {null, "testhostnameport", null, "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", null, "testcerthash", null, "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {null, "testhostnameport", "testcerthash", "testcertstorename", null, "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", null, "testcerthash", "testcertstorename", "testsslctlidentifier", null, (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {null, "testhostnameport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", null, (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", null, "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), null, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {null, "testhostnameport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, null, (bool?) false, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", null, "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, null, (bool?) true, (bool?) false, (bool?) true, (bool?) false},
				new object[] {null, "testhostnameport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, null, (bool?) false, (bool?) true, (bool?) false},
				new object[] {"testipport", null, "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, null, (bool?) true, (bool?) false},
				new object[] {null, "testhostnameport", "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, null, (bool?) false},
				new object[] {"testipport", null, "testcerthash", "testcertstorename", "testsslctlidentifier", "testsslctlstorename", (Guid?) new Guid("11111111-1111-1111-1111-111111111111"), (uint?) 1, (uint?) 1, (bool?) false, (bool?) true, (bool?) false, (bool?) true, null}
			};

			foreach (var values in tests)
			{
				var nullValueIndices = values.Select((val, idx) => Tuple.Create(val, idx)).Where(t => t.Item1 == null).Select(t => t.Item2).ToArray();
				

				new NetSH(harness).Http.Add.SSLCert(ipPort:										(string)values[0],
													hostnamePort:								(string)values[1],
													certHash:									(string)values[2],
													certStoreName:								(string)values[3],
													sslCtlIdentifier:							(string)values[4],
													sslCtlStoreName:							(string)values[5],
													appId:										(Guid?) values[6],
													revocationFreshnessTime:					(uint?) values[7],
													urlRetrievalTimeout:						(uint?) values[8],
													verifyClientCertRevocation:					(bool?) values[9],
													verifyRevocationWithCachedClientCertOnly:	(bool?) values[10],
													usageCheck:									(bool?) values[11],
													dsMapperUsage:								(bool?) values[12],
													clientCertNegotiation:						(bool?) values[13]);

				var value = harness.Value;
				var parameters = typeof (IAddAction).GetMethod("SSLCert").GetParameters();
				var i = 0;
				parameters.ToList().ForEach(x =>
				{
					var type = x.ParameterType;
					var name = x.Name.ToLower();

					if (nullValueIndices.Contains(i))
					{
						Assert.IsTrue(!value.Contains(name + "="));
						i++;
						return;
					}

					if (type == typeof (string))
						Assert.IsTrue(value.Contains(name + "=" + "test" + name));
					else if (type == typeof (Guid))
						Assert.IsTrue(value.Contains(name + "={11111111-1111-1111-1111-111111111111}"));
					else if (type == typeof(Guid?))
						Assert.IsTrue(value.Contains(name + "={11111111-1111-1111-1111-111111111111}"));
					else if (type == typeof (bool) || type == typeof(bool?))
						Assert.IsTrue(value.Contains(name + "=enable") || value.Contains(name + "=disable"));
					i++;
				});
			}
		}
		// ReSharper restore RedundantArgumentName

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