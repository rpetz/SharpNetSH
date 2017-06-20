using System.ComponentModel;

namespace Ignite.SharpNetSH.WLAN
{
    public enum Cost
    {
        [Description("default")]
        Default,
        [Description("unrestricted")]
        Unrestricted,
        [Description("fixed")]
        Fixed,
        [Description("variable")]
        Variable,

    }
}
