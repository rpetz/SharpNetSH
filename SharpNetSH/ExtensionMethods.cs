using System;

namespace Ignite.SharpNetSH
{
	internal static class ExtensionMethods
	{
		public static String ToYesNo(this bool? value)
		{ return ((bool) value ? "yes" : "no"); }

		public static String ToEnabledDisabled(this bool? value)
		{ return ((bool)value ? "enabled" : "disabled"); }
	}
}