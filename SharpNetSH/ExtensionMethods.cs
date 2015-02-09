using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Ignite.SharpNetSH
{
	internal static class ExtensionMethods
	{
		public static String ToYesNo(this bool? value)
		{ return ((bool) value ? "yes" : "no"); }

		public static String ToEnabledDisabled(this bool? value)
		{ return ((bool)value ? "enabled" : "disabled"); }

		public static String ProcessParameters(this MethodBase method, params object[] values)
		{
			var parameters = method.GetParameters().ToList();
			var results = new List<String>();
			var i = 0;
			foreach (var parameter in parameters) {
				var value = values[i];
				i++;
				var parameterName = parameter.GetParameterName();

				if (value == null) continue;

				if (value is Boolean? || value is Boolean) {
					results.Add(GetParameterOutput(parameterName, parameter.GetBooleanType(), (Boolean)value));
					continue;
				}

				if (value.GetType().IsEnum) {
					results.Add(parameterName + "=" + value.GetDescription());
					continue;
				}

				// Otherwise it's a stringable property
				if (value != null)
					results.Add(parameterName + "=" + value);
			}
			if (results.Count == 0) return method.GetMethodName();
			return method.GetMethodName() + " " + results.Aggregate((x, y) => String.IsNullOrWhiteSpace(x) ? y : x + " " + y);
		}

		public static String GetParameterOutput(String parameterName, BooleanType booleanType, Boolean inputValue)
		{
			if (booleanType == BooleanType.EnableDisable) return parameterName + "=" + (inputValue ? "enabled" : "disabled");
			if (booleanType == BooleanType.YesNo) return parameterName + "=" + (inputValue ? "yes" : "no");
			throw new Exception("Invalid boolean type");
		}

		public static String GetMethodName(this MethodBase method)
		{
			foreach (var attribute in Attribute.GetCustomAttributes(method).OfType<MethodNameAttribute>())
				return (attribute).MethodName;
			return method.Name;
		}

		public static String GetParameterName(this ParameterInfo parameter)
		{
			foreach (var attribute in Attribute.GetCustomAttributes(parameter).OfType<ParameterNameAttribute>())
				return (attribute).ParameterName;
			return parameter.Name;
		}

		public static BooleanType GetBooleanType(this ParameterInfo parameter)
		{
			foreach (var attribute in Attribute.GetCustomAttributes(parameter).OfType<ParameterNameAttribute>())
				return (attribute).BooleanType;
			throw new Exception("Missing boolean type");
		}

		public static string GetDescription<T>(this T enumerationValue)
		{
			var type = enumerationValue.GetType();
			if (!type.IsEnum)
				throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");

			//Tries to find a DescriptionAttribute for a potential friendly name
			//for the enum
			var memberInfo = type.GetMember(enumerationValue.ToString());
			if (memberInfo != null && memberInfo.Length > 0)
			{
				var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

				if (attrs != null && attrs.Length > 0)
				{
					//Pull out the description value
					return ((DescriptionAttribute)attrs[0]).Description;
				}
			}
			//If we have no description attribute, just return the ToString of the enum
			return enumerationValue.ToString();

		}
	}
}