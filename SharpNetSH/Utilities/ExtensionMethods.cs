using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

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

		public static Type GetResponseProcessorType(this MethodBase method)
		{
			return Attribute.GetCustomAttributes(method).OfType<ResponseProcessorAttribute>().Select(attribute => (attribute).ResponseProcessorType).FirstOrDefault();
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

		public static Boolean GetEnumerableType<T>(this Type type)
		{
			return type == typeof(IEnumerable<T>);
		}

		public static Boolean IsEnumerable<T>(this Type type)
		{ return type == typeof(IEnumerable<T>); }
		
		public static void ProcessRawData(this IOutputObject outputObject, String splitRegex, IEnumerable<String> lines)
		{
			foreach (var line in lines)
			{
				var regex = new Regex(splitRegex);
				var split = regex.Split(line.Trim(), 2);
				if (split.Length != 2)
					throw new Exception("Invalid Raw Certificate Data.  Line: " + line);

				var title = split[0];
				var value = split[1];
				if (value.ToLower() == "(null)")
					value = null;

				outputObject.AddValue(title, value);
			}
		}
	}
}