using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Ignite.SharpNetSH
{
	public class ActionProxy<TInterface> : RealProxy
	{
		private readonly String _priorText;
		private readonly String _actionName;
		private readonly IExecutionHarness _harness;

		private ActionProxy(String actionName, String priorText, IExecutionHarness harness) : base(typeof(TInterface))
		{
			_actionName = actionName;
			_harness = harness;
			_priorText = priorText;
		}

		public static TInterface Create(String actionName, String priorText, IExecutionHarness harness)
		{ return (TInterface)new ActionProxy<TInterface>(actionName, priorText, harness).GetTransparentProxy(); }

		public override IMessage Invoke(IMessage msg)
		{
			var methodCall = (IMethodCallMessage)msg;
			var method = (MethodInfo)methodCall.MethodBase;
			var result = method.ProcessParameters(methodCall.InArgs);
			_harness.Execute(_priorText + " " + _actionName + " " + result);
			return new ReturnMessage(null, null, 0, methodCall.LogicalCallContext, methodCall);
		}
	}
}