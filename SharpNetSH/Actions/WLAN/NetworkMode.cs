using System.ComponentModel;

namespace Ignite.SharpNetSH.WLAN
{
    public enum NetworkMode
    {
        [Description("ssid")]
        Ssid,
        [Description("bssid")]
        Bssid
    }
}