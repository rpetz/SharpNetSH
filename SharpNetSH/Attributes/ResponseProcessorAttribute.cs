using System;
using System.Linq;

namespace Ignite.SharpNetSH
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ResponseProcessorAttribute : Attribute
	{
		public Type ResponseProcessorType { get; private set; }

		public ResponseProcessorAttribute(Type responseProcessorType)
		{
			if (!responseProcessorType.GetInterfaces().Contains(typeof (IResponseProcessor)))
				throw new Exception("Invalid response processor type applied to attribute");
			ResponseProcessorType = responseProcessorType;
		}
	}
}