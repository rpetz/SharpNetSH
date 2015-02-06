using System;

namespace Ignite.SharpNetSH
{
	public class HttpAction : IHttpAction, IAction
	{
		private String _priorText;
		private IExecutionHarness _harness;
		private Boolean _initialized;

		public string ActionName { get { return "http"; } }

		public IAddAction Add
		{
			get
			{
				if (!_initialized)
					throw new Exception("Actions must be initialized prior to use.");

				var action = new AddAction();
				action.Initialize(_priorText, _harness);
				return action;
			}
		}

		public IDeleteAction Delete
		{
			get
			{
				if (!_initialized)
					throw new Exception("Actions must be initialized prior to use.");

				var action = new DeleteAction();
				action.Initialize(_priorText, _harness);
				return action;
			}
		}

		public IFlushAction Flush
		{
			get
			{
				if (!_initialized)
					throw new Exception("Actions must be initialized prior to use.");

				var action = new FlushAction();
				action.Initialize(_priorText, _harness);
				return action;
			}
		}
		public IShowAction Show
		{
			get
			{
				if (!_initialized)
					throw new Exception("Actions must be initialized prior to use.");

				var action = new ShowAction();
				action.Initialize(_priorText, _harness);
				return action;
			}
		}

		public void Initialize(String priorText, IExecutionHarness harness)
		{
			_harness = harness;
			_priorText = priorText + " " + ActionName;
			_initialized = true;
		}
	}
}