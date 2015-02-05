using System;

namespace Ignite.SharpNetSH
{
	public class AddAction : IAddAction, IAction
	{
		private String _priorText;
		private Boolean _initialized;
		private IConsoleHarness _harness;

		public string ActionName { get { return "add"; } }

		public void Initialize(String priorText, IConsoleHarness harness)
		{
			_priorText = priorText + " " + ActionName;
			_harness = harness;
			_initialized = true;
		}
	}
}