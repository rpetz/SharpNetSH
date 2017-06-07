using System;

namespace Ignite.SharpNetSH.WLAN
{
    public interface IShowAction
    {
        /// <summary>
        /// Shows the global settings of wireless LAN.
        /// </summary>
        /// <returns></returns>
        [MethodName("settings")]
        [ResponseProcessor(typeof(TrimProcessor))]
        IResponse Settings();

        /// <summary>
        /// Displays whether WLAN AutoConfig service is enabled or disabled
        /// </summary>
        /// <returns></returns>
        [MethodName("autoconfig")]
        [ResponseProcessor(typeof(TrimProcessor))]
        IResponse AutoConfig();

        /// <summary>
        /// Displays the global setting whether to display or hide blocked networks in the visible network list
        /// </summary>
        /// <returns></returns>
        [MethodName("blockednetworks")]
        [ResponseProcessor(typeof(TrimProcessor))]
        IResponse BlockedNetworks();

        /// <summary>
        /// Displays a list of the current wireless interfaces on a computer.
        /// </summary>
        /// <returns></returns>
        [MethodName("networks")]
        [ResponseProcessor(typeof(BlockProcessor), @"\s+:\s+")]
        IResponse Networks([ParameterName("interface")] string @interface = null, [ParameterName("mode")] string mode = null);

        /// <summary>
        /// Displays the entire collection of information about wireless network adapters, wireless profiles and wireless networks.
        /// </summary>
        /// <returns></returns>
        [MethodName("all")]
        [ResponseProcessor(typeof(TrimProcessor))]
        IResponse All();
    }
}
