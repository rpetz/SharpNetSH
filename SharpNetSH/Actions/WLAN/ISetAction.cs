using System;

namespace Ignite.SharpNetSH.WLAN
{
    public interface ISetAction
    {
        /// <summary>
        ///  Specify whether to allow or disallow shared user credentials
        ///  on the client for network authentication.
        /// </summary>
        /// <param name="allow">Allow or disallow shared user credentials. Required.</param>
        /// <returns></returns>
        [MethodName("allowexplicitcreds")]
        IResponse AllowExplicitCreds([ParameterName("allow", BooleanType.YesNo)] Boolean allow);

        /// <summary>
        /// Enable or disable the auto configuration logic on an interface.
        /// If it is, disabled then Windows will not connect to any wireless network automatically 
        /// from the specified interface.
        /// </summary>
        /// <param name="enabled">Set auto configuration logic to enabled or disabled. Required.</param>
        /// <param name="_interface">Name of the interface for which the setting has to be changed. Required.</param>
        /// <returns></returns>
        [MethodName("autoconfig")]
        IResponse AutoConfig([ParameterName("enabled", BooleanType.YesNo)] Boolean enabled, [ParameterName("interface")] string _interface);

        /// <summary>
        /// Specify whether to show or hide blocked networks in the visible network list. 
        /// If disabled then the blocked networks will not be displayed in the visible wireless network list.
        /// </summary>
        /// <param name="display"> Show or hide blocked networks in the visible network list. Required. </param>
        /// <returns></returns>
        [MethodName("blockednetwork")]
        IResponse BlockedNetwork([ParameterName("display")] Display display);

        /// <summary>
        /// Modifies the specified timer. The value is specified in minutes.  
        /// The blocked state is reset upon a manual connection attempt, a session change or a media connect.
        /// </summary>
        /// <param name="value">Value (0-60).</param>
        /// <returns></returns>
        [MethodName("blockperiod")]
        IResponse BlockPeriod([ParameterName("value")] uint value);

        /// <summary>
        ///  If enabled is yes then everyone is allowed to create all user profiles.
        /// </summary>
        /// <param name="enabled">Required.</param>
        /// <returns></returns>
        [MethodName("createalluserprofile")]
        IResponse CreateAllUserProfile([ParameterName("enabled", BooleanType.YesNo)] Boolean enabled);

        /// <summary>
        ///  This command changes the properties of hosted network, including: SSID
        ///  of the hosted network, allow or disallow the hosted network in the system,
        ///  and a user security key that is used by the hosted network.
        /// </summary>
        /// <param name="mode"> Specifies whether to allow or disallow the hosted network.</param>
        /// <param name="ssid">SSID of the hosted network.</param>
        /// <param name="key"> The user security key should be a string with 8 to 63 ASCII characters,
        ///  eg. a passphrase, or 64 hexadecimal digits which represent 32 binary bytes.</param>
        /// <param name="keyUsage"> Specifies whether the user security key is persistent or temporary.
        ///  If keyUsage is specified as persistent, the security key will be saved
        ///  and used when the hosted network is started again in future. Otherwise
        ///  it will be used only when the current or next time the hosted network
        ///  is started. Once the hosted network is stopped, the temporary security
        ///  key will be deleted from the system. If keyUsage is not specified, it
        ///  is persistent by default.</param>
        /// <returns></returns>
        [MethodName("hostednetwork")]
        IResponse HostedNetwork([ParameterName("mode")] Mode mode, [ParameterName("ssid")] String ssid = null, [ParameterName("key")] String key = null, [ParameterName("keyusage")] KeyUsage? keyUsage = null);

        /// <summary>
        /// Set the preference order of a wireless network profile on an interface. All three parameters are required. 
        /// Only the order of User profiles can be changed. 
        /// Group policy profiles are read only. 
        /// Group policy profiles always have higher precedence over User profiles.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="_interface"></param>
        /// <param name="priority"> Specifies the new position of the profile in the preferred profile list. If it is 1, the profile will be moved to the first position in the User profile list.</param>
        /// <returns></returns>
        [MethodName("profileorder")]
        IResponse ProfileOrder([ParameterName("name")] string name, [ParameterName("interface")] string _interface, [ParameterName("priority")] int priority);

        /// <summary>
        /// Modifies the specified profile. If the interface is specified then only the profile on that interface is modified. 
        /// The name parameter is required. At least one other parameter besides profile name and interface must also be specified.
        /// </summary>
        /// <param name="name">Name of the profile to be modified.</param>
        /// <param name="_interface"> Name of the interface on which the profile is set.</param>
        /// <param name="ssidName">SSID of the wireless LAN, maximum length is 32.</param>
        /// <param name="connectionType">Specify the network is infrastructure (ESS) or ad-hoc (IBSS).</param>
        /// <param name="autoSwitch">The roaming behavior of an auto-connected network when a more preferred network is in range.</param>
        /// <param name="connectionMode"> Connecting to network automatic or manually. Must be manual if connection type is IBSS.</param>
        /// <param name="nonBroadcast">Whether to connect to a hidden network.</param>
        /// <param name="authentication">The authentication type to be used.</param>
        /// <param name="encryption">The encryption method to be used.</param>
        /// <param name="keyType">Whether the shared key is a network key or a passphrase.</param>
        /// <param name="keyIndex">The key index should be used to encrypt wireless traffic (1-4).</param>
        /// <param name="keyMaterial">The network key or pasphrase.</param>
        /// <param name="pmkCacheMode"> Whether PMK caching will be used. Only valid for WPA2 networks.</param>
        /// <param name="pmkCacheSize">The length of time in seconds, that a PMK cache will be kept (1-255).</param>
        /// <param name="pmkCacheTtl">The length of time in seconds, that a PMK cache will be kept (300-86400).</param>
        /// <param name="preAuthMode"> Whether preauthentication will be used. Only valid for WPA2 networks.</param>
        /// <param name="preAuthThrottle">The number of reauthentication attempts to try on neighboring APs (1-16).</param>
        /// <param name="fips">Enable or Disable FIPS mode.</param>
        /// <param name="useOneX">Whether 802.1X authentication is used.</param>
        /// <param name="authMode">Type of credentials to be used for authentication.</param>
        /// <param name="ssoMode"> Type of single sign on to be attempted if any.</param>
        /// <param name="maxDelay">Timeout value to establish single sign on connection (1-120).</param>
        /// <param name="allowDialog"> Allow or Disallow a dialog to be shown for preLogon.</param>
        /// <param name="userVLAN"> Specify if the network switches to a different VLAN on user authentication.</param>
        /// <param name="heldPeriod">The interval time between two attempt authentications, in seconds (1-3600).</param>
        /// <param name="authPeriod"> The maximum time, in seconds, a client waits for a response from the authenticator (1-3600).</param>
        /// <param name="startPeriod">The length of time, in seconds, to wait before an EAPOL-Start</param>
        /// <param name="maxStart">The maximum number of EAPOL-Start messages sent (1-100).</param>
        /// <param name="maxAuthFailures">The maximum number of authentication failures allowed for a set of credential (1-100).</param>
        /// <param name="cacheUserData">Whether the user credentials are cached for subsequent use.</param>
        /// <param name="cost">The cost associated with the profile.</param>
        /// <returns></returns>
        [MethodName("profileparameter")]
        IResponse ProfileParameter([ParameterName("name")] string name,
            [ParameterName("interface")] String _interface = null,
            [ParameterName("SSIDname")] String ssidName = null,
            [ParameterName("ConnectionType")] ConnectionType? connectionType = null,
            [ParameterName("autoSwitch", BooleanType.YesNo)] Boolean? autoSwitch = null,
            [ParameterName("ConnectionMode")] ConnectionMode? connectionMode = null,
            [ParameterName("nonBroadcast", BooleanType.YesNo)] Boolean? nonBroadcast = null,
            [ParameterName("authentication")] Authentication? authentication = null,
            [ParameterName("encryption")] Encryption? encryption = null,
            [ParameterName("keyType")] KeyType? keyType = null,
            [ParameterName("keyIndex")] uint? keyIndex = null,
            [ParameterName("keyMaterial")] String keyMaterial = null,
            [ParameterName("PMKCacheMode", BooleanType.YesNo)] Boolean? pmkCacheMode = null,
            [ParameterName("PMKCacheSize")] uint? pmkCacheSize = null,
            [ParameterName("PMKCacheTTL")] uint? pmkCacheTtl = null,
            [ParameterName("preAuthMode", BooleanType.YesNo)] Boolean? preAuthMode = null,
            [ParameterName("preAuthThrottle")] uint? preAuthThrottle = null,
            [ParameterName("FIPS", BooleanType.YesNo)] Boolean? fips = null,
            [ParameterName("useOneX", BooleanType.YesNo)] Boolean? useOneX = null,
            [ParameterName("authMode")] AuthMode? authMode = null,
            [ParameterName("ssoMode")] SsoMode? ssoMode = null,
            [ParameterName("maxDelay")] uint? maxDelay = null,
            [ParameterName("allowDialog", BooleanType.YesNo)] Boolean? allowDialog = null,
            [ParameterName("userVLAN", BooleanType.YesNo)] Boolean? userVLAN = null,
            [ParameterName("heldPeriod")] uint? heldPeriod = null,
            [ParameterName("AuthPeriod")] uint? authPeriod = null,
            [ParameterName("StartPeriod")] uint? startPeriod = null,
            [ParameterName("maxStart")] uint? maxStart = null,
            [ParameterName("maxAuthFailures")] uint? maxAuthFailures = null,
            [ParameterName("cacheUserData", BooleanType.YesNo)] Boolean? cacheUserData = null,
            [ParameterName("cost")] Cost? cost = null);

        /// <summary>
        /// Changes the profile type for the specified profile. If the interface is 
        /// specified, then only the profile on that interface is changed.
        /// </summary>
        /// <param name="name">Name of the profile to be changed. Required.</param>
        /// <param name="profileType">The desired profile type [all-user/per-user]. Required.</param>
        /// <param name="_interface">Name of the interface on which the profile is set.</param>
        /// <returns></returns>
        [MethodName("profiletype")] 
        IResponse ProfileType([ParameterName("name")] String name, [ParameterName("profiletype")] ProfileType profileType, [ParameterName("interface")] String _interface = null);

        /// <summary>
        /// Enabled or disable tracing, with the option to make tracing persistent. 
        /// If enabled then the trace logs for wireless LAN will be collected and 
        /// saved to the trace files.
        /// </summary>
        /// <param name="mode">Enable, make it persistent or disable tracing. Required.</param>
        /// <returns></returns>
        [MethodName("tracing")]
        IResponse Tracing([ParameterName("mode")] TracingMode mode);
    }
}
