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

		public void SSLCert(string ipPort, string certHash = null, string certStoreName = null, string sslCtlIdentifier = null, string sslCtlStoreName = null, Guid? appId = null, uint? revocationFreshnessTime = null, uint? urlRetrievalTimeout = null, bool? verifyClientCertRevocation = null, bool? verifyRevocationWithCachedClientCertOnly = null, bool? usageCheck = null, bool? dsMapperUsage = null, bool? clientCertNegotation = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void Timeout(Timeout timeoutType, ushort value)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void UrlAcl(string url, string user, string sddl = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void UrlAcl(string url, string user, bool? listenUrls = null, bool? delegateUrls = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void Initialize(String priorText, IExecutionHarness harness)
		{
			_priorText = priorText + " " + ActionName;
			_harness = harness;
			_initialized = true;
		}
	}
}