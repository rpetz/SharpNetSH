using System;
using Ignite.SharpNetSH.WLAN.Enums;

namespace Ignite.SharpNetSH.WLAN
{
    public interface IAddAction
    {
        /// <summary>
        /// Adds a wireless network into the allowed and blocked network list configured on the system.
        /// If permission is denyall then ssid should not be given. 
        /// </summary>
        /// <param name="permission">Permission type of the filter.</param>
        /// <param name="ssid">SSID of the wireless network.</param>
        /// <param name="networktype">Network type of the wireless network.</param>
        /// <returns></returns>
        [MethodName("filter")]
        IResponse Filter([ParameterName("permission")] Permission permission, [ParameterName("ssid")] String ssid, [ParameterName("networktype")] NetworkType networktype);

        /// <summary>
        /// Add a wireless network profile on an interface for all or current users.
        /// </summary>
        /// <param name="filename">Parameter filename is required. It is the name of the XML file containing the profile data.</param>
        /// <param name="_interface"> Parameter interface is optional. 
        /// It is one of the interface name shown by "netsh wlan show interface" command. 
        /// If interface name is given, the profile will be added to the specified interface, otherwise the profile will be added on all wireless interfaces.</param>
        /// <param name="user">Parameter user is optional. It specifies whether this profile is applied to all users or current user only. By default it is applied to all users.</param>
        /// <returns></returns> 
        [MethodName("profile")]
        IResponse Profile([ParameterName("filename")] String filename, [ParameterName("interface")] String _interface = null, [ParameterName("user")] User? user = null);
    }
}
