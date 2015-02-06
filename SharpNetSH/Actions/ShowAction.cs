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

		public IEnumerable<CacheEntry> CacheState(string url = null)
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " cachestate";
			if (!String.IsNullOrWhiteSpace(url)) text += " url=" + url;
			var rawOutput = _harness.Execute(text);

			var entries = new List<CacheEntry>();
			if (rawOutput == null || rawOutput.Contains("There were no cache entries corresponding to the provided URL")) return entries;

			var currentEntryRows = new List<string>();
			foreach (var line in rawOutput.Skip(3))
			{
				if (String.IsNullOrWhiteSpace(line))
				{
					if (currentEntryRows.Count > 0)
					{
						var entry = new CacheEntry();
						ProcessRawCertificateData(entry, @":\s+", currentEntryRows);
						entries.Add(entry);
					}
					currentEntryRows = new List<string>();
				}
				else
					currentEntryRows.Add(line);
			}

			return entries;
		}

		public IEnumerable<String> IpListen()
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			var text = _priorText + " iplisten";
			var rawOutput = _harness.Execute(text);

			var entries = new List<String>();
			if (rawOutput == null) return entries;
			entries = rawOutput.Skip(3).Where(line => !String.IsNullOrWhiteSpace(line)).Select(line => line.Trim()).ToList();
			return entries;
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
			if (rawOutput == null || rawOutput.Contains("The system cannot find the file specified.")) return certificates;

			var currentCertificateRows = new List<string>();
			foreach (var line in rawOutput.Skip(3))
			{
				if (String.IsNullOrWhiteSpace(line))
				{
					if (currentCertificateRows.Count > 0)
					{
						var certificate = new SSLCertificate();
						ProcessRawCertificateData(certificate, @"\s+:\s+", currentCertificateRows);
						certificates.Add(certificate);
					}
					currentCertificateRows = new List<string>();
				}
				else
					currentCertificateRows.Add(line);
			}

			return certificates;
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

		private void ProcessRawCertificateData(OutputObject outputObject, String splitRegex, IEnumerable<String> lines)
		{
			foreach (var line in lines)
			{
				var regex = new Regex(splitRegex);
				var split = regex.Split(line.Trim(), 2);
				if (split.Length != 2)
					throw new Exception("Invalid Raw Certificate Data.  Line: " + line);

				var title = split[0];
				var value = split[1];
				if (value.ToLower() == "(null)")
					value = null;

				outputObject.AddValue(title, value);
			}
		}
	}
}