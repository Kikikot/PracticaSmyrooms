using ExternalLibraries.ConfigSystem;
using ExternalLibraries.Global;
using ExternalLibraries.LoggSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaSmyroomsTest._Emulation;
using RecomendedHotelsNotificatorService.Services;
using System;
using System.Linq;

namespace PracticaSmyroomsTest.MailSenderManagerTest
{
    [TestClass]
    public class MailSenderManagerTest
    {
        [TestMethod]
        public void SendEmail_KeyInConfig_NotError()
        {
            bool error = false;
            int? preCount = null;
            int? postCount = null;

            try
            {
                Emulation.InitDDBB();

                var config = (EmulatedConfig)Global.Resolve<IConfig>();
                config.Set("NotifierService:MailSender", "test@sender.mail");

                var logger = (OwnLogger)Global.Resolve<ILogger>();
                preCount = OwnLogger.AllLogs.Count();

                var mailSenderManager = Global.Resolve<IMailSenderManager>();
                mailSenderManager.SendEmail("client2@test.mail", "Just some subject", "just some body");

                postCount = OwnLogger.AllLogs.Count();

            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(preCount);
            Assert.IsNotNull(postCount);
            Assert.IsTrue(preCount.Value == 0);
            Assert.IsTrue(postCount.Value == 1);
        }


        [TestMethod]
        public void SendEmail_KeyNotInConfig_Error()
        {
            bool error = false;
            int? preCount = null;
            int? postCount = null;

            try
            {
                Emulation.InitDDBB();

                var logger = (OwnLogger)Global.Resolve<ILogger>();
                preCount = OwnLogger.AllLogs.Count();

                var mailSenderManager = Global.Resolve<IMailSenderManager>();
                mailSenderManager.SendEmail("client2@test.mail", "Just some subject", "just some body");

                postCount = OwnLogger.AllLogs.Count();

            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsTrue(error);
            Assert.IsNotNull(preCount);
            Assert.IsNull(postCount);
            Assert.IsTrue(preCount.Value == 0);
        }
    }
}
