using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.SharpNetSH.WLAN
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
