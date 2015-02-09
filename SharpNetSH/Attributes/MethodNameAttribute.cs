using System;

namespace Ignite.SharpNetSH
{
	[AttributeUsage(AttributeTargets.Method)]
	public class MethodNameAttribute : Attribute
	{
		public MethodNameAttribute(string methodName)
		{ MethodName = methodName; }

		public String MethodName { get; private set; }
	}
}