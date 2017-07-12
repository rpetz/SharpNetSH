using System;

namespace Ignite.SharpNetSH
{
	[AttributeUsage(AttributeTargets.Field)]
	internal class BooleanValueAttribute : Attribute
	{
		public String TrueValue { get; }
		public String FalseValue { get; }

		public BooleanValueAttribute(string trueValue, string falseValue)
		{
			TrueValue = trueValue;
			FalseValue = falseValue;
		}
	}
}