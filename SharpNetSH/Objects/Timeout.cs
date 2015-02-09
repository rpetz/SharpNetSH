using System.ComponentModel;

namespace Ignite.SharpNetSH
{
	public enum Timeout
	{
		[Description("idleconnectiontimeout")]
		IdleConnectionTimeout,
		[Description("headerwaittimeout")]
		HeaderWaitTimeout
	}
}