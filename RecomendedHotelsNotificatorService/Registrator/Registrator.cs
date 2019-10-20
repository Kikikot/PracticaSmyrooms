using Domain.ClientAggregate.Repositories;
using Domain.HotelAggregate.Repositories;
using Domain.HotelTypeAggregate.Repositories;
using Domain.RegionAggregate.Repositories;
using ExternalLibraries.ConfigSystem;
using ExternalLibraries.Global;
using ExternalLibraries.LoggSystem;
using ExternalLibraries.MailSystem;
using ExternalLibraries.TemplateReaderSystem;
using RecomendedHotelsNotificatorService.Repositories;
using RecomendedHotelsNotificatorService.Services;

namespace RecomendedHotelsNotificatorService.Registrator
{
    public static class Registrator
    {
        public static void Register()
        {
            Global.Register<IConfig, Config>();
            Global.Register<ILogger, OwnLogger>();
            Global.Register<IMailSender, MailSender>();
            Global.Register<ITemplateReader, TemplateReader>();
            Global.Register<IMailSenderManager, MailSenderManager>();
            Global.Register<IRegionsRepository, RegionsRepository>();
            Global.Register<IHotelTypesRepository, HotelTypesRepository>();
            Global.Register<IHotelsRepository, HotelsRepository>();
            Global.Register<IClientsRepository, ClientsRepository>();
            Global.Register<IRecomendator, Recomendator>();
        }
    }
}
