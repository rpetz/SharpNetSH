using System;

namespace Ignite.SharpNetSH
{
	public class ShowAction : IShowAction, IAction
	{
		private String _priorText;
		private Boolean _initialized;
		private IConsoleHarness _harness;

		public string ActionName { get { return "show"; } }

		public void CacheState(string url = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void IpListen()
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void ServiceState(View? view = null, bool? verbose = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void SSLCert(string ipPort = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void Timeout()
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void UrlAcl(string url = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void Initialize(String priorText, IConsoleHarness harness)
		{
			_priorText = priorText + " " + ActionName;
			_harness = harness;
			_initialized = true;
		}
	}
}