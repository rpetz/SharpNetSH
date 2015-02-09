using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Ignite.SharpNetSH
{
	public class ActionProxy<TInterface> : RealProxy
	{
		private readonly String _priorText;
		private readonly IExecutionHarness _harness;
		private readonly TInterface _instance;

		private ActionProxy(TInterface instance, String priorText, IExecutionHarness harness) : base(typeof(TInterface))
		{
			_instance = instance;
			_harness = harness;
			_priorText = priorText;
		}

		public static TInterface Create(TInterface instance, String priorText, IExecutionHarness harness)
		{ return (TInterface)new ActionProxy<TInterface>(instance, priorText, harness).GetTransparentProxy(); }

		public override IMessage Invoke(IMessage msg)
		{
			var methodCall = (IMethodCallMessage)msg;
			var method = (MethodInfo)methodCall.MethodBase;
			var result = method.ProcessParameters(methodCall.InArgs);
			_harness.Execute(_priorText + " " + ((IActionNameProvider)_instance).ActionName + " " + result);
			return new ReturnMessage(null, null, 0, methodCall.LogicalCallContext, methodCall);
		}
	}
}