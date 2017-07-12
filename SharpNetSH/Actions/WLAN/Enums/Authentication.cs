using System.ComponentModel;

namespace Ignite.SharpNetSH.WLAN.Enums
{
    public enum Authentication
    {
        [Description("open")]
        Open,
        [Description("shared")]
        Shared,
        [Description("WPA")]
        Wpa,
        [Description("WPA2")]
        Wpa2,
        [Description("WPAPSK")]
        WpaPsk,
        [Description("WPA2PSK")]
        Wpa2Psk
    }
}
