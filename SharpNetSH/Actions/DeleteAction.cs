using System;

namespace Ignite.SharpNetSH
{
	internal class DeleteAction : IDeleteAction, IActionNameProvider
	{
		public string ActionName { get { return "delete"; } }

		public void Cache(string url, bool? recursive = null)
		{ throw new CannotDirectlyCallException(); }

		public void IpListen(string ipAddress)
		{ throw new CannotDirectlyCallException(); }

		public void SSLCert(string ipPort)
		{ throw new CannotDirectlyCallException(); }

		public void Timeout(Timeout timeoutType)
		{ throw new CannotDirectlyCallException(); }

		public void UrlAcl(string url)
		{ throw new CannotDirectlyCallException(); }
	}
}