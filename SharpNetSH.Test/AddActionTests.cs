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
		public void VerifyIPListenOutput()
		{
			var harness = new StringHarness();
			new NetSH(harness).Http.Add.IPListen("test");
			Assert.AreEqual(harness.Value, "netsh http add iplisten address=test");
		}

		[TestMethod]
		public void VerifySSLCertOutput()
		{
			var harness = new StringHarness();
			var adder = new NetSH(harness).Http.Add;

			var parameters = new object[][]
			{
				new object[] {"certHash", "test"},
				new object[] {"appId", new Guid("00112233-4455-6677-8899-AABBCCDDEEFF"), "{00112233-4455-6677-8899-AABBCCDDEEFF}"},
				new object[] {"certStoreName", "test"},
				new object[] {"verifyClientCertRevocation", true, "enable"},
				new object[] {"verifyClientCertRevocation", false, "disable"},
				new object[] {"verifyRevocationWithCachedClientCertonly", true, "enable"},
				new object[] {"verifyRevocationWithCachedClientCertonly", false, "disable"},
				new object[] {"usageCheck", true, "enable"},
				new object[] {"usageCheck", false, "disable"},
				new object[] {"revocationFreshnessTime", "1"},
				new object[] {"urlRetrievalTimeout", "1"},
				new object[] {"sslCtlIdentifier", true, "test"},
				new object[] {"sslctlStoreName", false, "test"},
				new object[] {"dsMapperUsage", true, "enable"},
				new object[] {"dsMapperUsage", false, "disable"},
				new object[] {"clientCertNegotation", true, "enable"},
				new object[] {"clientCertNegotation", false, "disable"}
			};

			var simplestCommand = "netsh http add sslcert ipport=test";
			var sslCertMethod = adder.GetType().GetMethods(BindingFlags.Public).FirstOrDefault(x => x.Name == "SSLCert");

			for (var x = 0; x < parameters.Length; x++)
			{
				var current = parameters[x];
				var parameterName = (String)current[0];
				var resultName = parameterName.ToLower();
				var input = current[1];
				var result = current[2];
				sslCertMethod.Invoke(adder, )
			}

			Assert.AreEqual(harness.Value, "netsh http add ");
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