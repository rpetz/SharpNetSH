using System;

namespace Ignite.SharpNetSH
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ResponseProcessorAttribute : Attribute
	{
		public Type ResponseProcessorType { get; private set; }

		public ResponseProcessorAttribute(Type responseProcessorType)
		{
			ResponseProcessorType = responseProcessorType;
		}
	}
}