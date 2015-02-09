using System;

namespace Ignite.SharpNetSH
{
	internal class AddAction : IAddAction, IActionNameProvider
	{
		public string ActionName { get { return "add"; } }

		public void IpListen(string ipAddress)
		{ throw new CannotDirectlyCallException(); }

		public void SSLCert(string ipPort, string certHash = null, string certStoreName = null, string sslCtlIdentifier = null, string sslCtlStoreName = null, Guid? appId = null, uint? revocationFreshnessTime = null, uint? urlRetrievalTimeout = null, bool? verifyClientCertRevocation = null, bool? verifyRevocationWithCachedClientCertOnly = null, bool? usageCheck = null, bool? dsMapperUsage = null, bool? clientCertNegotiation = null)
		{ throw new CannotDirectlyCallException(); }

		public void Timeout(Timeout timeoutType, ushort value)
		{ throw new CannotDirectlyCallException(); }

		public void UrlAcl(string url, string user, string sddl = null)
		{ throw new CannotDirectlyCallException(); }

		public void UrlAcl(string url, string user, bool? listenUrls = null, bool? delegateUrls = null)
		{ throw new CannotDirectlyCallException(); }
	}
}