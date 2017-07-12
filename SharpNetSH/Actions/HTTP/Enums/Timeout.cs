using System.ComponentModel;

namespace Ignite.SharpNetSH.HTTP.Enums
{
	public enum Timeout
	{
		[Description("idleconnectiontimeout")]
		IdleConnectionTimeout,
		[Description("headerwaittimeout")]
		HeaderWaitTimeout
	}
}