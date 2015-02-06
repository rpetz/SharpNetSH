using System;

namespace Ignite.SharpNetSH
{
	public class AddAction : IAddAction, IAction
	{
		private String _priorText;
		private Boolean _initialized;
		private IExecutionHarness _harness;

		public string ActionName { get { return "add"; } }

		public void IPListen(string address)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " iplisten";

			if (!String.IsNullOrWhiteSpace(address))
				text += " address=" + address;

			_harness.Execute(text);
		}

		public void SSLCert(string ipPort, string certHash = null, string certStoreName = null, string sslCtlIdentifier = null, string sslCtlStoreName = null, Guid? appId = null, 
							uint? revocationFreshnessTime = null, uint? urlRetrievalTimeout = null, bool? verifyClientCertRevocation = null, bool? verifyRevocationWithCachedClientCertOnly = null, 
							bool? usageCheck = null, bool? dsMapperUsage = null, bool? clientCertNegotation = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " sslcert ipport=" + ipPort;

			if (!String.IsNullOrWhiteSpace(certHash)) text += " certhash=" + certHash;
			if (!String.IsNullOrWhiteSpace(certStoreName)) text += " certstorename=" + certStoreName;
			if (!String.IsNullOrWhiteSpace(sslCtlIdentifier)) text += " sslctlidentifier=" + sslCtlIdentifier;
			if (!String.IsNullOrWhiteSpace(sslCtlStoreName)) text += " sslctlstorename=" + sslCtlStoreName;
			
			if (appId != null) text += " appid={" + appId + "}";
			
			if (revocationFreshnessTime != null) text += " revocationfreshnesstime=" + revocationFreshnessTime;
			if (urlRetrievalTimeout != null) text += " urlretrievaltimeout=" + urlRetrievalTimeout;

			if (verifyClientCertRevocation != null) text += " verifyclientcertrevocation=" + ((bool)verifyClientCertRevocation ? "enabled" : "disabled");
			if (verifyRevocationWithCachedClientCertOnly != null) text += " verifyrevocationwithcachedclientcertonly=" + ((bool)verifyRevocationWithCachedClientCertOnly ? "enabled" : "disabled");
			if (usageCheck != null) text += " usagecheck=" + ((bool)usageCheck ? "enabled" : "disabled");
			if (dsMapperUsage != null) text += " dsmapperusage=" + ((bool)dsMapperUsage ? "enabled" : "disabled");
			if (clientCertNegotation != null) text += " clientcertnegotation=" + ((bool)clientCertNegotation ? "enabled" : "disabled");

			_harness.Execute(text);
		}

		public void Timeout(Timeout timeoutType, ushort value)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " timeout timeouttype=" + timeoutType.ToString().ToLower() + " value=" + value;
			_harness.Execute(text);
		}

		public void UrlAcl(string url, string user, string sddl = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " urlacl url=" + url + " user=" + user;
			if (!String.IsNullOrWhiteSpace(sddl)) text += " sddl=" + sddl;
			_harness.Execute(text);
		}

		public void UrlAcl(string url, string user, bool? listenUrls = null, bool? delegateUrls = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " urlacl url=" + url + " user=" + user;
			if (listenUrls != null) text += " listen=" + ((bool)listenUrls ? "yes" : "no");
			if (delegateUrls != null) text += " delegate=" + ((bool)delegateUrls ? "yes" : "no");
			_harness.Execute(text);
		}

		public void Initialize(String priorText, IExecutionHarness harness)
		{
			_priorText = priorText + " " + ActionName;
			_harness = harness;
			_initialized = true;
		}
	}
}