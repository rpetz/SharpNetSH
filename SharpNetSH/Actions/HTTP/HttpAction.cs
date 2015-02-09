using System;

namespace Ignite.SharpNetSH.HTTP
{
	internal class HttpAction : IHttpAction, IAction
	{
		private String _priorText;
		private IExecutionHarness _harness;
		private Boolean _initialized;

		public string ActionName { get { return "http"; } }

		private HttpAction()
		{ }

		internal static IHttpAction CreateAction(String priorText, IExecutionHarness harness)
		{
			var action = new HttpAction();
			action.Initialize(priorText, harness);
			return action;
		}

		public IAddAction Add
		{
			get
			{
				if (!_initialized)
					throw new Exception("Actions must be initialized prior to use.");

				return ActionProxy<IAddAction>.Create("add", _priorText, _harness);
			}
		}

		public IDeleteAction Delete
		{
			get
			{
				if (!_initialized)
					throw new Exception("Actions must be initialized prior to use.");

				return ActionProxy<IDeleteAction>.Create("delete", _priorText, _harness);
			}
		}

		public IFlushAction Flush
		{
			get
			{
				if (!_initialized)
					throw new Exception("Actions must be initialized prior to use.");

				return ActionProxy<IFlushAction>.Create("flush", _priorText, _harness);
			}
		}
		public IShowAction Show
		{
			get
			{
				if (!_initialized)
					throw new Exception("Actions must be initialized prior to use.");

				return ActionProxy<IShowAction>.Create("show", _priorText, _harness);
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