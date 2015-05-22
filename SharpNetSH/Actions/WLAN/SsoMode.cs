using System.ComponentModel;

namespace Ignite.SharpNetSH.WLAN
{
    public enum SsoMode
    {
        [Description("preLogon")]
        PreLogon,
        [Description("postLogon")]
        PostLogon,
        [Description("none")]
        None
    }
}
