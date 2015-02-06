using System;
using System.Text;

namespace Ignite.SharpNetSH
{
	public class FlushAction : IFlushAction, IAction
	{
		private String _priorText;
		private Boolean _initialized;
		private IExecutionHarness _harness;

		public string ActionName { get { return "flush"; } }

		public void LogBuffer()
		{
			if (!_initialized)
				throw new Exception("Actions must be initialized prior to use.");

			_harness.Execute(_priorText + " logbuffer");
		}

		public void Initialize(String priorText, IExecutionHarness harness)
		{
			_priorText = priorText + " " + ActionName;
			_harness = harness;
			_initialized = true;
		}
	}
}