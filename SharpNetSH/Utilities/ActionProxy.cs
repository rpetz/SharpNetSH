using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Serialization;

namespace Ignite.SharpNetSH
{
	internal class ActionProxy<TInterface> : RealProxy
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
			var result = ProcessParameters(method, methodCall);
			int exitCode;
			var response = _harness.Execute(_priorText + " " + _actionName + " " + result, out exitCode);
			var processorType = method.GetResponseProcessorType();
			var splitRegEx = method.GetSplitRegEx();

			// If there is a ResponseProcessorAttribute defined, it overrides any response processors on the return type
			if (processorType != null)
			{
				// We use the Activator here because we want custom processors to use their own constructor if they so desire
				var processorUnknown = FormatterServices.GetUninitializedObject(processorType);
				var isSimpleProcessor = processorUnknown.GetType().GetInterfaces().Contains(typeof (IResponseProcessor));

				if (!isSimpleProcessor)
					throw new Exception("Custom processor cannot inherit from both IResponseProcessor and IMultiResponseProcessor");

				var simpleProcessor = (IResponseProcessor) processorUnknown;
				var processedResponse = simpleProcessor.ProcessResponse(response, exitCode, splitRegEx);
				return new ReturnMessage(processedResponse, null, 0, methodCall.LogicalCallContext, methodCall);
			}

			return new ReturnMessage(null, null, 0, methodCall.LogicalCallContext, methodCall);
		}

		private String ProcessParameters(MethodBase method, IMethodCallMessage methodCall)
		{
			var results = new List<String>();
			var i = 0;
			foreach (var value in methodCall.InArgs)
			{
				var parameter = method.GetParameters().FirstOrDefault(x => x.Name == methodCall.GetInArgName(i));
				var parameterName = parameter.GetParameterName();
				i++;

				if (value == null) continue;

				if (value is Boolean?)
					// We have to process booleans differently based upon the configured boolean type (i.e. Yes/No, Enabled/Disabled, True/False outputs) 
					results.Add(parameterName + "=" + parameter.GetBooleanType().GetBooleanValue((Boolean) value));
				else if (value.GetType().IsEnum)
					// Enums might be configured with a custom description to change how to output their text
					results.Add(parameterName + "=" + value.GetDescription());
				else
					// Otherwise it's a stringable (i.e. ToString()) property
					results.Add(parameterName + "=" + value);
			}
			if (results.Count == 0) return method.GetMethodName();
			return method.GetMethodName() + " " + results.Aggregate((x, y) => String.IsNullOrWhiteSpace(x) ? y : x + " " + y);
		}
	}
}