using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
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

		public static Type GetResponseProcessorType(this MethodInfo method)
		{
			var attr = Attribute.GetCustomAttributes(method).OfType<ResponseProcessorAttribute>().Select(attribute => (attribute).ResponseProcessorType).FirstOrDefault();
			return attr ?? method.ReturnType;
		}

		public static String GetSplitRegEx(this MethodInfo method)
		{
			return Attribute.GetCustomAttributes(method).OfType<ResponseProcessorAttribute>().Select(attribute => (attribute).SplitRegEx).FirstOrDefault();
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

		public static KeyValuePair<String, dynamic> ProcessRawData(this String line, String splitRegEx)
		{
			var regex = new Regex(splitRegEx);
			var split = regex.Split(line.TrimStart(), 2);
			if (split.Length == 1)
				split = new[] {split[0], "!#COLLECTION"};
			if (split.Length != 2)
				throw new Exception("Invalid RegEx for line: " + line);

			var title = split[0];
			object value = split[1];
			switch (((String)value).ToLower())
			{
				case "(null)":
					value = null;
					break;
				case "yes":
				case "enabled":
					value = true;
					break;
				case "no":
				case "disabled":
					value = false;
					break;
			}

			var textInfo = new CultureInfo("en-US", false).TextInfo;
			var titleCaseTitle = Regex.Replace(textInfo.ToTitleCase(title), @"\s+", "");
			titleCaseTitle = Regex.Replace(titleCaseTitle, "[^a-zA-Z0-9 -]", ""); // Remove any non-alphanumeric characters
			return new KeyValuePair<String, dynamic>(titleCaseTitle, value);
		}

		public static dynamic ProcessRawData(this IEnumerable<String> lines, String splitRegEx)
		{
			var outputObject = new ExpandoObject();
			foreach (var line in lines)
			{
				var processedLine = line.ProcessRawData(splitRegEx);
				((IDictionary<string, object>)outputObject)[processedLine.Key] = processedLine.Value;
			}
			return outputObject;
		}
	}
}