using System.ComponentModel;

namespace Ignite.SharpNetSH.WLAN
{
    public enum Encryption
    {
        [Description("none")]
        None,
        [Description("WEP")]
        Wep,
        [Description("TKIP")]
        Tkip,
        [Description("AES")]
        Aes,
    }
}
