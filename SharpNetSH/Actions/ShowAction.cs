using System;

namespace Ignite.SharpNetSH
{
	internal class ShowAction : IShowAction, IAction
	{
		private String _priorText;
		private Boolean _initialized;
		private IExecutionHarness _harness;

		public string ActionName { get { return "show"; } }

		private ShowAction()
		{ }

		internal static IShowAction CreateAction(String priorText, IExecutionHarness harness)
		{
			var action = new ShowAction();
			action.Initialize(priorText, harness);
			return action;
		}

		public void CacheState(string url = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " cachestate";
			if (!String.IsNullOrWhiteSpace(url)) text += " url=" + url;
			_harness.Execute(text);
		}

		public void IpListen()
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " iplisten";
			_harness.Execute(text);
		}

		public void ServiceState(View? view = null, bool? verbose = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " servicestate";
			if (view != null) text += " view=" + view.ToString().ToLower();
			if (verbose != null) text += " verbose=" + verbose.ToYesNo();
			_harness.Execute(text);
		}

		public void SSLCert(string ipPort = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " sslcert";
			if (!String.IsNullOrWhiteSpace(ipPort)) text += " ipport=" + ipPort;
			_harness.Execute(text);
		}

		public void Timeout()
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " timeout";
			_harness.Execute(text);
		}

		public void UrlAcl(string url = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " urlacl";
			if (!String.IsNullOrWhiteSpace(url)) text += " url=" + url;
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