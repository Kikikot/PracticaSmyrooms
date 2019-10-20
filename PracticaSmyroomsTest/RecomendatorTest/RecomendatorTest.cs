using ExternalLibraries.ConfigSystem;
using ExternalLibraries.Global;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaSmyroomsTest._Emulation;
using RecomendedHotelsNotificatorService;
using System;

namespace PracticaSmyroomsTest.RecomendatorTest
{
    [TestClass]
    public class RecomendatorTest
    {
        [TestMethod]
        public void SendRecomendations_NotError()
        {
            bool error = false;

            try
            {
                Emulation.InitDDBB();

                var config = (EmulatedConfig)Global.Resolve<IConfig>();
                config.Set("NotifierService:MailSender", "test@sender.mail");

                var recomendator = Global.Resolve<IRecomendator>();

                recomendator.SendRecomendations();
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
        }
    }
}
