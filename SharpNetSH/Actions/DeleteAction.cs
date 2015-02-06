using System;

namespace Ignite.SharpNetSH
{
	public class DeleteAction : IDeleteAction, IAction
	{
		private String _priorText;
		private Boolean _initialized;
		private IExecutionHarness _harness;

		public string ActionName { get { return "delete"; } }

		public void Cache(string url, bool? recursive = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " url=" + url;
			if (recursive != null)
				text += " recursive=" + recursive.ToYesNo();

			_harness.Execute(text);
		}

		public void IpListen(string address)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void SSLCert(string ipPort)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void Timeout(Timeout timeoutType)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			throw new NotImplementedException();
		}

		public void UrlAcl(string url)
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