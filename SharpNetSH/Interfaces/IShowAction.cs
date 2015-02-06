using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	public interface IShowAction
	{
		/// <summary>
		/// Lists all resources and their associated properties that are cached in the HTTP response cache or displays a single resource and its associated properties.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307240(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="url">Fully qualified URL. If unspecified, implies all URLs. The URL can also be a prefix to registered URLs.</param>
		IEnumerable<CacheEntry> CacheState(String url = null);

		/// <summary>
		/// Lists all IP addresses in the IP listen list. The IP listen list is used to scope the list of addresses to which the HTTP service binds. "0.0.0.0" means any IPv4 address and "::" means any IPv6 address.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307241(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		void IpListen();

		/// <summary>
		/// Shows a snapshot of the HTTP service.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307242(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="view">View snapshot of HTTP service state based on server session or request queues.</param>
		/// <param name="verbose">View verbose information showing property information too.</param>
		void ServiceState(View? view = null, Boolean? verbose = null);

		/// <summary>
		/// Lists SSL server certificate bindings and the corresponding client certificate policies for an IP address and port.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307243(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="ipPort">Specifies the IPv4 or IPv6 address and port for which the SSL certificate bindings will be displayed. Not specifying an ipport lists all bindings.</param>
		IEnumerable<SSLCertificate> SSLCert(String ipPort = null);

		/// <summary>
		/// Shows the timeout values of the service (in seconds).
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307244(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		void Timeout();

		/// <summary>
		/// Lists DACLs for the specified reserved URL or all reserved URLs.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307245(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="url">Specifies the fully qualified URL. If unspecified, implies all URLs.</param>
		void UrlAcl(String url = null);
	}
}