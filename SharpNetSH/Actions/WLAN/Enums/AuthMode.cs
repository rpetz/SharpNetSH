using System.ComponentModel;

namespace Ignite.SharpNetSH.WLAN.Enums
{
    public enum AuthMode
    {
        [Description("machineOrUser")]
        MachineOrUser,
        [Description("machineOnly")]
        MachineOnly,
        [Description("userOnly")]
        UserOnly,
        [Description("guest")]
        Guest
    }
}
