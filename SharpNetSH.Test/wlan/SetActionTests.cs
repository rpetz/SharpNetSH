using System;
using Ignite.SharpNetSH.WLAN;
using Ignite.SharpNetSH.Test.Spike;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ignite.SharpNetSH.Test.wlan
{
    [TestClass]
    public class SetActionTests
    {
        [TestMethod]
        public void VerifyAllowExplicitCredsOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Set.AllowExplicitCreds(true);
            Assert.AreEqual("netsh wlan set allowexplicitcreds allow=yes", harness.Value);

            new NetSH(harness).Wlan.Set.AllowExplicitCreds(false);
            Assert.AreEqual("netsh wlan set allowexplicitcreds allow=no", harness.Value);
        }

        [TestMethod]
        public void VerifyAutoConfigOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Set.AutoConfig(true, "\"Wireless Network Connection\"");
            Assert.AreEqual("netsh wlan set autoconfig enabled=yes interface=\"Wireless Network Connection\"", harness.Value);

            new NetSH(harness).Wlan.Set.AutoConfig(false, "\"Wireless Network Connection\"");
            Assert.AreEqual("netsh wlan set autoconfig enabled=no interface=\"Wireless Network Connection\"", harness.Value);
        }

        [TestMethod]
        public void VerifyBlockedNetworkOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Set.BlockedNetwork(Display.Show);
            Assert.AreEqual("netsh wlan set blockednetworks display=show", harness.Value);

            new NetSH(harness).Wlan.Set.BlockedNetwork(Display.Hide);
            Assert.AreEqual("netsh wlan set blockednetworks display=hide", harness.Value);
        }

        [TestMethod]
        public void VerifyBlockPeriodOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Set.BlockPeriod(50);
            Assert.AreEqual("netsh wlan set blockperiod value=50", harness.Value);

            new NetSH(harness).Wlan.Set.BlockPeriod(0);
            Assert.AreEqual("netsh wlan set blockperiod value=0", harness.Value);
        }

        [TestMethod]
        public void VerifyCreateAllUserProfileOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Set.CreateAllUserProfile(true);
            Assert.AreEqual("netsh wlan set createalluserprofile enabled=yes", harness.Value);

            new NetSH(harness).Wlan.Set.CreateAllUserProfile(false);
            Assert.AreEqual("netsh wlan set createalluserprofile enabled=no", harness.Value);
        }

        [TestMethod]
        public void VerifyHostedNetworkOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Set.HostedNetwork(Mode.Allow);
            Assert.AreEqual("netsh wlan set hostednetwork mode=allow", harness.Value);

            new NetSH(harness).Wlan.Set.HostedNetwork(Mode.Disallow);
            Assert.AreEqual("netsh wlan set hostednetwork mode=disallow", harness.Value);

            new NetSH(harness).Wlan.Set.HostedNetwork(null, "ssid1");
            Assert.AreEqual("netsh wlan set hostednetwork ssid=ssid1", harness.Value);

            new NetSH(harness).Wlan.Set.HostedNetwork(null, null, "passphrase", KeyUsage.Persistent);
            Assert.AreEqual("netsh wlan set hostednetwork key=passphrase keyUsage=persistent", harness.Value);
        }

        [TestMethod]
        public void VerifyProfileOrderOutput()
        {
            var harness = new StringHarness();
            new NetSH(harness).Wlan.Set.ProfileOrder("\"profile1\"", "\"Wireless Network Connection\"", 1);
            Assert.AreEqual("set profileorder name=\"profile1\" interface=\"Wireless Network Connection\" priority=1", harness.Value);

            new NetSH(harness).Wlan.Set.ProfileOrder("\"profile1\"", "\"Wireless Network Connection\"", 5);
            Assert.AreEqual("set profileorder name=\"profile two\" interface=\"Wireless Network Connection\" priority=5", harness.Value);
        }

        [TestMethod]
        public void VerifyProfileParameterOutput()
        {
            var harness = new StringHarness();
           
            /*
            var tests = new[]
			{
				new object[] {"Profile1", "interfacename",  "ssid1",    ConnectionType.Ibss,    null,   null,                   false,  Authentication.Wpa2,    Encryption.Wep, KeyType.Passphrase, null,   null,           false,  null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", null,             "ssid1",    ConnectionType.Ess,     true,   ConnectionMode.Auto,    false,  null,                   null,           null,               null,   null,           null,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", null,             null,       null,                   true,   null,                   null,   Authentication.Wpa,     null,           KeyType.NetworkKey, 1,      "keymaterial",  null,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},  
				new object[] {"Profile1", null,             null,       null,                   true,   ConnectionMode.Manual,  null,   Authentication.Open,    null,           null,               null,   null,           true,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", null,             "ssid1",    null,                   null,   null,                   null,   Authentication.Open,    null,           null,               null,   null,           null,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", null,             "ssid1",    null,                   null,   null,                   true,   Authentication.Open,    null,           null,               null,   null,           null,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", "interfacename",  "ssid1",    null,                   false,  null,                   null,   null,                   null,           null,               null,   null,           true,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", "interfacename",  "ssid1",    null,                   null,   null,                   null,   null,                   null,           null,               null,   null,           null,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", "interfacename",  "ssid1",    null,                   null,   ConnectionMode.Manual,  true,   null,                   null,           null,               null,   null,           null,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", "interfacename",  "ssid1",    null,                   false,  null,                   null,   null,                   null,           null,               null,   null,           null,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", "interfacename",  "ssid1",    ConnectionType.Ess,     null,   null,                   null,   null,                   null,           null,               null,   null,           false,  null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", "interfacename",  "ssid1",    ConnectionType.Ess,     null,   null,                   null,   null,                   null,           null,               null,   null,           null,   null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
				new object[] {"Profile1", "interfacename",  "ssid1",    ConnectionType.Ibss}
			};

            foreach (var test in tests)
            {
                new NetSH(harness).Wlan.Set.ProfileParameter((string)test[0], (string)test[1], (string)test[2], (ConnectionType?)test[3]);
               // Assert.AreEqual(harness, "expected output");
            }
            */

            new NetSH(harness).Wlan.Set.ProfileParameter("profile_name", "interface sl", "ssid1", null, false,ConnectionMode.Auto);
            Assert.AreEqual(harness.Value, "netsh wlan set profileparameter name=profile_name interface=interface sl SSIDname=ssid1 autoSwitch=no ConnectionMode=auto");

            new NetSH(harness).Wlan.Set.ProfileParameter("Profile1", null, null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,AuthMode.UserOnly,SsoMode.PreLogon);
            Assert.AreEqual(harness.Value, "netsh wlan set profileparameter name=Profile1 authMode=userOnly ssoMode=preLogon");

            new NetSH(harness).Wlan.Set.ProfileParameter("Profile2", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,null, true, null, null, SsoMode.None);
            Assert.AreEqual(harness.Value, "netsh wlan set profileparameter name=Profile2 FIPS=yes ssoMode=none");
        }
    }
}
