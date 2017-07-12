using System;

namespace Ignite.SharpNetSH
{
	[AttributeUsage(AttributeTargets.Parameter)]
	internal class ParameterNameAttribute : Attribute
	{
		public ParameterNameAttribute(string parameterName) {
			ParameterName = parameterName;
		}

		public ParameterNameAttribute(string parameterName, BooleanType booleanType)
		{
			ParameterName = parameterName;
			BooleanType = booleanType;
		}

		public String ParameterName { get; }
		public BooleanType BooleanType { get; }
	}
}