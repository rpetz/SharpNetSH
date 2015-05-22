using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.SharpNetSH.WLAN
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
