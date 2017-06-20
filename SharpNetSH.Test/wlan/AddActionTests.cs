using Ignite.SharpNetSH.WLAN;
using Ignite.SharpNetSH.Test.Spike;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ignite.SharpNetSH.Test.wlan
{
    [TestClass]
    public class AddActionTests
    {
        [TestMethod]
        public void VerifyFilterOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Add.Filter(Permission.Allow, "ssidallowed", NetworkType.AdHoc);
			Assert.AreEqual("netsh wlan add filter permission=allow ssid=ssidallowed networktype=adhoc", harness.Value);

            new NetSH(harness).Wlan.Add.Filter(Permission.Block, "ssid1", NetworkType.Infrastructure);
            Assert.AreEqual("netsh wlan add filter permission=block ssid=ssid1 networktype=infrastructure", harness.Value);

            new NetSH(harness).Wlan.Add.Filter(Permission.DenyAll, null, NetworkType.Infrastructure);
            Assert.AreEqual("netsh wlan add filter permission=denyall networktype=infrastructure", harness.Value);
        }

        [TestMethod]
        public void VerifyProfileOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Add.Profile("profiledata.xml");
            Assert.AreEqual("netsh wlan add profile filename=profiledata.xml", harness.Value);

            new NetSH(harness).Wlan.Add.Profile("\"Profile1.xml\"", "\"Wireless Network Connection\"", User.Current);
            Assert.AreEqual("netsh wlan add profile filename=\"Profile1.xml\" interface=\"Wireless Network Connection\" user=current", harness.Value);

            new NetSH(harness).Wlan.Add.Profile("\"Profile1.xml\"", null, User.All);
            Assert.AreEqual("netsh wlan add profile filename=\"Profile1.xml\" user=all", harness.Value);
        }
    }
}
