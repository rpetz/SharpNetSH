using System.ComponentModel;

namespace Ignite.SharpNetSH.WLAN
{
    public enum KeyType
    {
        [Description("networkKey")]
        NetworkKey,
        [Description("passphrase")]
        Passphrase
    }
}
