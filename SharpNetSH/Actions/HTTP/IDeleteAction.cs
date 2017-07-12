using System;
using Ignite.SharpNetSH.HTTP.Enums;

namespace Ignite.SharpNetSH.HTTP
{
	public interface IDeleteAction
	{
		/// <summary>
		/// Flushes the entire URL cache or deletes entries according to the specified URL.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307225(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="url">Required. Specifies the fully qualified URL.</param>
		/// <param name="recursive">If true, removes all entries under the specified URL.</param>
		[MethodName("cache")]
		IResponse Cache([ParameterName("url")] String url, [ParameterName("recursive", BooleanType.YesNo)] Boolean? recursive = null);

		/// <summary>
		/// Specifies an IPv4 or IPv6 address to be deleted from the IP listen list.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307227(v=vs.85).aspx">MSDN</a>.<br></br>
		/// REMARKS: Deletes an IP address to the IP listen list. This does not include the port number. The IP listen list is used to scope the list of addresses to which the HTTP service binds. "0.0.0.0" means any IPv4 address and "::" means any IPv6 address.
		/// </summary>
		/// <param name="ipAddress">Specifies the IPv4 or IPv6 address to be deleted from the IP listen list.</param>
		[MethodName("iplisten")]
		IResponse IpListen([ParameterName("ipaddress")] String ipAddress);

		/// <summary>
		/// Deletes SSL server certificate bindings and the corresponding client certificate policies for an IP address and port.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307229(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="ipPort">Specifies the IPv4 or IPv6 address and port for which the SSL certificate bindings will be deleted.</param>
		/// <param name="ipPort">Specifies the hostname and port for which the SSL certificate bindings will be deleted.</param>
		[MethodName("sslcert")]
		IResponse SSLCert([ParameterName("ipport")] String ipPort = null, [ParameterName("hostnameport")] String hostnamePort = null);

		/// <summary>
		/// Deletes a global timeout and makes the HTTP.sys service revert to default values.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307230(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="timeoutType">Specifies the type of timeout setting.</param>
		[MethodName("timeout")]
		IResponse Timeout([ParameterName("timeouttype")] Timeout timeoutType);

		/// <summary>
		/// Deletes a reserved URL.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307231(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="url">Specifies the fully qualified URL.</param>
		[MethodName("urlacl")]
		IResponse UrlAcl([ParameterName("url")] String url);
	}
}