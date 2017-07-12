using System;

namespace Ignite.SharpNetSH
{
	[AttributeUsage(AttributeTargets.Method)]
	internal class MethodNameAttribute : Attribute
	{
		public MethodNameAttribute(string methodName)
		{ MethodName = methodName; }

		public String MethodName { get; }
	}
}