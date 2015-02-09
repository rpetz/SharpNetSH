using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Ignite.SharpNetSH
{
	internal static class ExtensionMethods
	{
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

		public static String GetBooleanValue(this BooleanType enumerationValue, Boolean value)
		{
			var attribute = enumerationValue.GetEnumValue<BooleanType, BooleanValueAttribute>();

			if (attribute == null)
				throw new Exception("Boolean enumerations must be annotated with a BooleanValueAttribute");

			return (value) ? attribute.TrueValue : attribute.FalseValue;
		}

		public static string GetDescription<TEnumeration>(this TEnumeration enumerationValue)
		{
			if (!enumerationValue.GetType().IsEnum)
				throw new Exception("Expected enum type");
			var attribute = enumerationValue.GetEnumValue<TEnumeration, DescriptionAttribute>();
			return attribute != null ? attribute.Description : enumerationValue.ToString();
		}

		public static TAttribute GetEnumValue<TEnumeration, TAttribute>(this TEnumeration enumerationValue) where TAttribute : class
		{
			if (!enumerationValue.GetType().IsEnum)
				throw new Exception("Expected enum type");
			
			var memberInfo = enumerationValue.GetType().GetMember(enumerationValue.ToString()).FirstOrDefault();
			if (memberInfo == null)
				return null;

			var attrs = memberInfo.GetCustomAttributes(typeof(TAttribute), false).FirstOrDefault();

			return (TAttribute)attrs;
		}
	}
}