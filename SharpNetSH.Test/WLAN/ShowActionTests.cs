using Ignite.SharpNetSH.Test.Spike;
using Ignite.SharpNetSH.WLAN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ignite.SharpNetSH.Test.WLAN
{
    [TestClass]
    public class ShowActionTests
    {
        [TestMethod]
        public void Test()
        {
            var netsh = new NetSH(new CommandLineHarness()).Wlan.Show.Settings();
        }

        [TestMethod]
        public void VerifySettings()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Show.Settings();
            Assert.AreEqual("netsh wlan show settings", harness.Value);
        }


        [TestMethod]
        public void VerifyAll()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Show.All();
            Assert.AreEqual("netsh wlan show all", harness.Value);
        }

        [TestMethod]
        public void VerifyNetworksOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Show.Networks(null,NetworkMode.Ssid);
            Assert.AreEqual("netsh wlan show networks mode=ssid", harness.Value);

            new NetSH(harness).Wlan.Show.Networks();
            Assert.AreEqual("netsh wlan show networks", harness.Value);
        }
    }
}
