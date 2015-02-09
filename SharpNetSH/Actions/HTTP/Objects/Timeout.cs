using System.ComponentModel;

namespace Ignite.SharpNetSH.HTTP
{
	public enum Timeout
	{
		[Description("idleconnectiontimeout")]
		IdleConnectionTimeout,
		[Description("headerwaittimeout")]
		HeaderWaitTimeout
	}
}