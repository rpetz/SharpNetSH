using System;

namespace Ignite.SharpNetSH.WLAN
{
    public interface IDeleteAction
    {

        /// <summary>
        /// Removes a wireless network from the allowed and blocked network list
        /// configured on the system.
        /// </summary>
        /// <param name="permission">Permission type of the filter.</param>
        /// <param name="ssid">SSID of the wireless network. Requiered if permission is allow or block. If permission is deny all then parameter should not be given. </param>
        /// <param name="networktype">Network type of the wireless network.</param>
        /// <returns></returns>
        [MethodName("filter")]
        IResponse Filter([ParameterName("permission")] Permission permission, [ParameterName("ssid")] String ssid, [ParameterName("networktype")] NetworkType networktype);

        /// <summary>
        /// Remove a wireless network profile from an interface or all interfaces.
        /// </summary>
        /// <param name="name">Name of the profile to delete. Parameter name is required.</param>
        /// <param name="_interface">Interface name. Parameter interface is optional. If it is given then the profile will be deleted from specified interface only. 
        /// If it is omitted then the profile will be deleted from all the interfaces that have such a profile.</param>
        /// <returns></returns>
        [MethodName("profile")]
        IResponse Profile([ParameterName("name")] String name, [ParameterName("interface")] String _interface);
    }
}
