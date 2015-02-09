using System.ComponentModel;

namespace Ignite.SharpNetSH.Test.Spike
{
	public enum DecoratedEnum
	{
		[Description("value1")]
		Value1,
		[Description("value2")]
		Value2
	}
}