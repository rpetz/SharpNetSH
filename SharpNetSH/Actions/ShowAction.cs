using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

		public IEnumerable<SSLCertificate> SSLCert(string ipPort = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " sslcert";
			if (!String.IsNullOrWhiteSpace(ipPort)) text += " ipport=" + ipPort;
			var rawOutput = _harness.Execute(text);

			var certificates = new List<SSLCertificate>();
			if (rawOutput == null) return certificates;

			var currentCertificateRows = new List<string>();
			foreach (var line in rawOutput.Skip(3))
			{
				if (String.IsNullOrWhiteSpace(line))
				{
					if (currentCertificateRows.Count > 0)
						certificates.Add(ProcessRawCertificateData(currentCertificateRows));
					currentCertificateRows = new List<string>();
				}
				else
					currentCertificateRows.Add(line);
			}

			return certificates;
		}

		private SSLCertificate ProcessRawCertificateData(IEnumerable<String> lines)
		{
			var certificate = new SSLCertificate();
			foreach (var line in lines)
			{
				var split = Regex.Split(line.Trim(), @"\s+:\s+");
				if (split.Length != 2) 
					throw new Exception("Invalid Raw Certificate Data.  Line: " + line);

				var title = split[0];
				var value = split[1];
				if (value.ToLower() == "(null)")
					value = null;

				certificate.AddValue(title, value);
			}
			return certificate;
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