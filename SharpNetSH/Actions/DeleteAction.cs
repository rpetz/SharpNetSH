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

			var text = _priorText + " cache url=" + url;
			if (recursive != null)
				text += " recursive=" + recursive.ToYesNo();

			_harness.Execute(text);
		}

		public void IpListen(string address)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " iplisten address=" + address;
			_harness.Execute(text);
		}

		public void SSLCert(string ipPort)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " sslcert ipport=" + ipPort;
			_harness.Execute(text);
		}

		public void Timeout(Timeout timeoutType)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " timeout timeouttype=" + timeoutType.ToString().ToLower();
			_harness.Execute(text);
		}

		public void UrlAcl(string url)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " urlacl url=" + url;
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