using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
			Assert.AreEqual(harness.Value, "netsh http add iplisten address=test");
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
			Assert.AreEqual(harness.Value, "netsh http add ");
		}

		[TestMethod]
		public void VerifyUrlAclOutput()
		{
			var harness = new StringHarness();
			Assert.AreEqual(harness.Value, "netsh http add ");
		}

		private object[] MapParameters(MethodBase method, IEnumerable<KeyValuePair<string, object>> namedParameters)
		{
			var paramNames = method.GetParameters().Select(p => p.Name).ToArray();
			var parameters = new object[paramNames.Length];
			for (var i = 0; i < parameters.Length; ++i)
			{
				parameters[i] = Type.Missing;
			}
			foreach (var item in namedParameters)
			{
				var paramName = item.Key;
				var paramIndex = Array.IndexOf(paramNames, paramName);
				parameters[paramIndex] = item.Value;
			}
			return parameters;
		}
	}
}