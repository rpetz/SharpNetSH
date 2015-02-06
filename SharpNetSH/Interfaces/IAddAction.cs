using System;

namespace Ignite.SharpNetSH
{
	public interface IAddAction
	{
		/// <summary>
		/// Specifies an IPv4 or IPv6 address to be added to the IP listen list. 
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307219(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="ipAddress"></param>
		void IPListen(String ipAddress);

		/// <summary>
		/// Adds a new Secure Sockets Layer (SSL) server certificate binding and the corresponding client certificate policies for an IP address and port.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307220(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="ipPort">Specifies the IP address and port for the binding.</param>
		/// <param name="certHash">Specifies the SHA hash of the certificate. This hash is 20 bytes long and specified as a hexadecimal string.</param>
		/// <param name="certStoreName">Specifies the store name for the certificate. Defaults to MY. Certificate must be stored in the local computer context.</param>
		/// <param name="sslCtlIdentifier">Lists the certificate issuers that can be trusted. This list can be a subset of the certificate issuers that are trusted by the computer.</param>
		/// <param name="sslCtlStoreName">Specifies the store name under LOCAL_MACHINE where SslCtlIdentifier is stored.</param>
		/// <param name="appId">Specifies the GUID to identify the owning application.</param>
		/// <param name="revocationFreshnessTime">Specifies the time interval to check for an updated certificate revocation list (CRL). If this value is 0, then the new CRL is updated only if the previous one expires (in seconds).</param>
		/// <param name="urlRetrievalTimeout">Specifies the timeout interval on attempts to retrieve the certificate revocation list for the remote URL (in milliseconds).</param>
		/// <param name="verifyClientCertRevocation">Turns on or turnsoff verification of revocation of client certificates.</param>
		/// <param name="verifyRevocationWithCachedClientCertOnly">Turns on or turns off usage of only cached client certificate for revocation checking.</param>
		/// <param name="usageCheck">Turns on or turns off usage check. Default is enabled.</param>
		/// <param name="dsMapperUsage">Turns on or turns off DS mappers. Default is disabled.</param>
		/// <param name="clientCertNegotation">Turns on or turns off negotiation of certificate. Default is disabled.</param>
		void SSLCert(String ipPort, String certHash = null, String certStoreName = null,
			String sslCtlIdentifier = null, String sslCtlStoreName = null,
			Guid? appId = null,
			UInt32? revocationFreshnessTime = null, UInt32? urlRetrievalTimeout = null,
			Boolean? verifyClientCertRevocation = null, Boolean? verifyRevocationWithCachedClientCertOnly = null,
			Boolean? usageCheck = null, Boolean? dsMapperUsage = null, Boolean? clientCertNegotation = null);

		/// <summary>
		/// Adds a global timeout to the HTTP.sys service.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307221(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="timeoutType">Specifies the type of timeout for setting.</param>
		/// <param name="value">Specifies the value of the timeout (in seconds). If value is hexadecimal, then add the prefix 0x.</param>
		void Timeout(Timeout timeoutType, UInt16 value);

		/// <summary>
		/// Reserves the specified URL for non-administrator users and accounts. The discretionary access control list (DACL) can be specified by using an account name with the listen and delegate parameters or by using a security descriptor definition language (SDDL) string.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307223(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="url">Specifies the fully qualified URL.</param>
		/// <param name="user">Specifies the user or user group name.</param>
		/// <param name="sddl">Specifies the SDDL string that describes the DACL.</param>
		void UrlAcl(String url, String user, String sddl = null);

		/// <summary>
		/// Reserves the specified URL for non-administrator users and accounts. The discretionary access control list (DACL) can be specified by using an account name with the listen and delegate parameters or by using a security descriptor definition language (SDDL) string.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307223(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="url">Specifies the fully qualified URL.</param>
		/// <param name="user">Specifies the user or user group name.</param>
		/// <param name="listenUrls">True: Allows the user to register URLs. This is the default value.<br></br>
		/// False: Denies the user from registering URLs.</param>
		/// <param name="delegateUrls">True: Allows the user to delegate URLs.<br></br>
		/// False: Denies the user from delegating URLs. This is the default value.</param>
		void UrlAcl(String url, String user, Boolean? listenUrls = null, Boolean? delegateUrls = null);
	}
}