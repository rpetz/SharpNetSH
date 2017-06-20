using System;
using Ignite.SharpNetSH.Test.Spike;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ignite.SharpNetSH.WLAN;

namespace Ignite.SharpNetSH.Test.wlan
{
    [TestClass]
    public class DeleteActionTests
    {
        [TestMethod]
        public void VerifyFilterOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Delete.Filter(Permission.DenyAll, null, NetworkType.AdHoc);
            Assert.AreEqual("netsh wlan delete filter permission=denyall networktype=adhoc", harness.Value);

            new NetSH(harness).Wlan.Delete.Filter(Permission.Allow, "ssid1", NetworkType.Infrastructure);
            Assert.AreEqual("netsh wlan delete filter permission=allow ssid=ssid1 networktype=infrastructure", harness.Value);
        }

        public void VerifyProfileOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Delete.Profile("\"Profile 1\"", "\"Wireless Network Connection\"");
            Assert.AreEqual("netsh wlan delete profile name=\"Profile 1\" interface=\"Wireless Network Connection\"", harness.Value);
        }
    }
}
