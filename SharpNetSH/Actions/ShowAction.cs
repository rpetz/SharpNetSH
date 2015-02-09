using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal class ShowAction : IShowAction, IActionNameProvider
	{
		public string ActionName { get { return "show"; } }

		public IEnumerable<CacheEntry> CacheState(string url = null)
		{ throw new CannotDirectlyCallException(); }

		public IEnumerable<String> IpListen()
		{ throw new CannotDirectlyCallException(); }

		public void ServiceState(View? view = null, bool? verbose = null)
		{ throw new CannotDirectlyCallException(); }

		public IEnumerable<SSLCertificate> SSLCert(string ipPort = null)
		{ throw new CannotDirectlyCallException(); }

		public TimeoutEntries Timeout()
		{ throw new CannotDirectlyCallException(); }

		public void UrlAcl(string url = null)
		{ throw new CannotDirectlyCallException(); }
	}
}