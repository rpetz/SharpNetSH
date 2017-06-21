using Ignite.SharpNetSH.HTTP;
using Ignite.SharpNetSH.WLAN;

namespace Ignite.SharpNetSH
{
	public interface INetSH
	{
		/// <summary>
		/// Represents an HTTP action (currently the only actions available in NetSH are HTTP).
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307236(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		IHttpAction Http { get; }

        IWlanAction Wlan { get; }
	}
}