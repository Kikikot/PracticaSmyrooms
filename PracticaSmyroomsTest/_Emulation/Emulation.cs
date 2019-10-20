using Domain.ClientAggregate;
using Domain.HotelAggregate;
using Domain.HotelTypeAggregate;
using Domain.RegionAggregate;
using ExternalLibraries.ConfigSystem;
using ExternalLibraries.Global;
using RecomendedHotelsNotificatorService.Registrator;
using RecomendedHotelsNotificatorService.Repositories;
using RecomendedHotelsNotificatorService.Services;
using System;

namespace PracticaSmyroomsTest._Emulation
{
    public static class Emulation
    {
        public static Guid IdTypeOnlyAdult = Guid.NewGuid();
        public static HotelType TypeOnlyAdult = new HotelType { Id = IdTypeOnlyAdult, Name = "OnlyAdult", Description = "Hotels reserved for adults", TemplatePath = "Templates/RecomendationsHotelTypeTemplate - OnlyAdults.html" };
        public static Guid IdTypeHotelSpa = Guid.NewGuid();
        public static HotelType TypeHotelSpa = new HotelType { Id = IdTypeHotelSpa, Name = "Hotel & Spa", Description = "Hotels with Spa", TemplatePath = "Templates/RecomendationsHotelTypeTemplate - HotelSpa.html" };
        public static Guid IdTypePremium = Guid.NewGuid();
        public static HotelType TypePremium = new HotelType { Id = IdTypePremium, Name = "Premium", Description = "Premium hotels in his category", TemplatePath = "Templates/RecomendationsHotelTypeTemplate - Premium.html" };

        public static Guid IdMallorca = Guid.NewGuid();
        public static Guid IdHotelMallorca01 = Guid.NewGuid();
        public static Guid IdHotelMallorca02 = Guid.NewGuid();
        public static Guid IdHotelMallorca03 = Guid.NewGuid();
        public static Guid IdHotelMallorca04 = Guid.NewGuid();
        public static Guid IdHotelMallorca05 = Guid.NewGuid();
        public static Guid IdHotelMallorca06 = Guid.NewGuid();
        public static Guid IdHotelMallorca07 = Guid.NewGuid();
        public static Guid IdHotelMallorca08 = Guid.NewGuid();
        public static Guid IdHotelMallorca09 = Guid.NewGuid();
        public static Guid IdHotelMallorca10 = Guid.NewGuid();
        public static Region Mallorca = new Region
        {
            Id = IdMallorca,
            Name = "Mallorca",
            Description = "Una isla de playas y montañas"
        };
        public static Hotel HotelMallorca01 = new Hotel { Id = IdHotelMallorca01, Name = "Hotel M 01", Category = "1*", Description = "Hotel 1º de 1 estrella en Mallorca Only Adults", RegionId = Mallorca.Id, HotelTypeId = IdTypeOnlyAdult };
        public static Hotel HotelMallorca02 = new Hotel { Id = IdHotelMallorca02, Name = "Hotel M 02", Category = "2*", Description = "Hotel 1º de 2 estrellas en Mallorca Premium", RegionId = Mallorca.Id, HotelTypeId = IdTypePremium };
        public static Hotel HotelMallorca03 = new Hotel { Id = IdHotelMallorca03, Name = "Hotel M 03", Category = "3*", Description = "Hotel 1º de 3 estrellas en Mallorca Spa", RegionId = Mallorca.Id, HotelTypeId = IdTypeHotelSpa };
        public static Hotel HotelMallorca04 = new Hotel { Id = IdHotelMallorca04, Name = "Hotel M 04", Category = "4*", Description = "Hotel 1º de 4 estrellas en Mallorca Only Adults", RegionId = Mallorca.Id, HotelTypeId = IdTypeOnlyAdult };
        public static Hotel HotelMallorca05 = new Hotel { Id = IdHotelMallorca05, Name = "Hotel M 05", Category = "5*", Description = "Hotel 1º de 5 estrellas en Mallorca Premium", RegionId = Mallorca.Id, HotelTypeId = IdTypePremium };
        public static Hotel HotelMallorca06 = new Hotel { Id = IdHotelMallorca06, Name = "Hotel M 06", Category = "1*", Description = "Hotel 2º de 1 estrella en Mallorca Spa", RegionId = Mallorca.Id, HotelTypeId = IdTypeHotelSpa };
        public static Hotel HotelMallorca07 = new Hotel { Id = IdHotelMallorca07, Name = "Hotel M 07", Category = "2*", Description = "Hotel 2º de 2 estrellas en Mallorca Only Adults", RegionId = Mallorca.Id, HotelTypeId = IdTypeOnlyAdult };
        public static Hotel HotelMallorca08 = new Hotel { Id = IdHotelMallorca08, Name = "Hotel M 08", Category = "3*", Description = "Hotel 2º de 3 estrellas en Mallorca Premium", RegionId = Mallorca.Id, HotelTypeId = IdTypePremium };
        public static Hotel HotelMallorca09 = new Hotel { Id = IdHotelMallorca09, Name = "Hotel M 09", Category = "4*", Description = "Hotel 2º de 4 estrellas en Mallorca Spa", RegionId = Mallorca.Id, HotelTypeId = IdTypeHotelSpa };
        public static Hotel HotelMallorca10 = new Hotel { Id = IdHotelMallorca10, Name = "Hotel M 10", Category = "5*", Description = "Hotel 2º de 5 estrellas en Mallorca Only Adults", RegionId = Mallorca.Id, HotelTypeId = IdTypeOnlyAdult };

        public static Guid IdIbiza = Guid.NewGuid();
        public static Guid IdHotelIbiza01 = Guid.NewGuid();
        public static Guid IdHotelIbiza02 = Guid.NewGuid();
        public static Guid IdHotelIbiza03 = Guid.NewGuid();
        public static Guid IdHotelIbiza04 = Guid.NewGuid();
        public static Guid IdHotelIbiza05 = Guid.NewGuid();
        public static Guid IdHotelIbiza06 = Guid.NewGuid();
        public static Guid IdHotelIbiza07 = Guid.NewGuid();
        public static Guid IdHotelIbiza08 = Guid.NewGuid();
        public static Guid IdHotelIbiza09 = Guid.NewGuid();
        public static Guid IdHotelIbiza10 = Guid.NewGuid();
        public static Region Ibiza = new Region
        {
            Id = IdIbiza,
            Name = "Ibiza",
            Description = "Una isla de fiesta donde desfasar"
        };
        public static Hotel HotelIbiza01 = new Hotel { Id = IdHotelIbiza01, Name = "Hotel I 01", Category = "1*", Description = "Hotel 1º de 1 estrella en Ibiza Premium", RegionId = Ibiza.Id, HotelTypeId = IdTypePremium };
        public static Hotel HotelIbiza02 = new Hotel { Id = IdHotelIbiza02, Name = "Hotel I 02", Category = "2*", Description = "Hotel 1º de 2 estrellas en Ibiza Spa", RegionId = Ibiza.Id, HotelTypeId = IdTypeHotelSpa };
        public static Hotel HotelIbiza03 = new Hotel { Id = IdHotelIbiza03, Name = "Hotel I 03", Category = "3*", Description = "Hotel 1º de 3 estrellas en Ibiza Only Adults", RegionId = Ibiza.Id, HotelTypeId = IdTypeOnlyAdult };
        public static Hotel HotelIbiza04 = new Hotel { Id = IdHotelIbiza04, Name = "Hotel I 04", Category = "4*", Description = "Hotel 1º de 4 estrellas en Ibiza Premium", RegionId = Ibiza.Id, HotelTypeId = IdTypePremium };
        public static Hotel HotelIbiza05 = new Hotel { Id = IdHotelIbiza05, Name = "Hotel I 05", Category = "5*", Description = "Hotel 1º de 5 estrellas en Ibiza Spa", RegionId = Ibiza.Id, HotelTypeId = IdTypeHotelSpa };
        public static Hotel HotelIbiza06 = new Hotel { Id = IdHotelIbiza06, Name = "Hotel I 06", Category = "1*", Description = "Hotel 2º de 1 estrella en Ibiza Only Adults", RegionId = Ibiza.Id, HotelTypeId = IdTypeOnlyAdult };
        public static Hotel HotelIbiza07 = new Hotel { Id = IdHotelIbiza07, Name = "Hotel I 07", Category = "2*", Description = "Hotel 2º de 2 estrellas en Ibiza Premium", RegionId = Ibiza.Id, HotelTypeId = IdTypePremium };
        public static Hotel HotelIbiza08 = new Hotel { Id = IdHotelIbiza08, Name = "Hotel I 08", Category = "3*", Description = "Hotel 2º de 3 estrellas en Ibiza Spa", RegionId = Ibiza.Id, HotelTypeId = IdTypeHotelSpa };
        public static Hotel HotelIbiza09 = new Hotel { Id = IdHotelIbiza09, Name = "Hotel I 09", Category = "4*", Description = "Hotel 2º de 4 estrellas en Ibiza Only Adults", RegionId = Ibiza.Id, HotelTypeId = IdTypeOnlyAdult };
        public static Hotel HotelIbiza10 = new Hotel { Id = IdHotelIbiza10, Name = "Hotel I 10", Category = "5*", Description = "Hotel 2º de 5 estrellas en Ibiza Premium", RegionId = Ibiza.Id, HotelTypeId = IdTypePremium };

        public static Guid IdFormentera = Guid.NewGuid();
        public static Guid IdHotelFormentera01 = Guid.NewGuid();
        public static Guid IdHotelFormentera02 = Guid.NewGuid();
        public static Guid IdHotelFormentera03 = Guid.NewGuid();
        public static Guid IdHotelFormentera04 = Guid.NewGuid();
        public static Guid IdHotelFormentera05 = Guid.NewGuid();
        public static Guid IdHotelFormentera06 = Guid.NewGuid();
        public static Guid IdHotelFormentera07 = Guid.NewGuid();
        public static Guid IdHotelFormentera08 = Guid.NewGuid();
        public static Guid IdHotelFormentera09 = Guid.NewGuid();
        public static Guid IdHotelFormentera10 = Guid.NewGuid();
        public static Region Formentera = new Region
        {
            Id = IdFormentera,
            Name = "Formentera",
            Description = "Una isla pequeña y colonizada por italianos"
        };
        public static Hotel HotelFormentera01 = new Hotel { Id = IdHotelFormentera01, Name = "Hotel F 01", Category = "1*", Description = "Hotel 1º de 1 estrella en Formentera Spa", RegionId = Formentera.Id, HotelTypeId = IdTypeHotelSpa };
        public static Hotel HotelFormentera02 = new Hotel { Id = IdHotelFormentera02, Name = "Hotel F 02", Category = "2*", Description = "Hotel 1º de 2 estrellas en Formentera Only Adults", RegionId = Formentera.Id, HotelTypeId = IdTypeOnlyAdult };
        public static Hotel HotelFormentera03 = new Hotel { Id = IdHotelFormentera03, Name = "Hotel F 03", Category = "3*", Description = "Hotel 1º de 3 estrellas en Formentera Premium", RegionId = Formentera.Id, HotelTypeId = IdTypePremium };
        public static Hotel HotelFormentera04 = new Hotel { Id = IdHotelFormentera04, Name = "Hotel F 04", Category = "4*", Description = "Hotel 1º de 4 estrellas en Formentera Spa", RegionId = Formentera.Id, HotelTypeId = IdTypeHotelSpa };
        public static Hotel HotelFormentera05 = new Hotel { Id = IdHotelFormentera05, Name = "Hotel F 05", Category = "5*", Description = "Hotel 1º de 5 estrellas en Formentera Only Adults", RegionId = Formentera.Id, HotelTypeId = IdTypeOnlyAdult };
        public static Hotel HotelFormentera06 = new Hotel { Id = IdHotelFormentera06, Name = "Hotel F 06", Category = "1*", Description = "Hotel 2º de 1 estrella en Formentera Premium", RegionId = Formentera.Id, HotelTypeId = IdTypePremium };
        public static Hotel HotelFormentera07 = new Hotel { Id = IdHotelFormentera07, Name = "Hotel F 07", Category = "2*", Description = "Hotel 2º de 2 estrellas en Formentera Spa", RegionId = Formentera.Id, HotelTypeId = IdTypeHotelSpa };
        public static Hotel HotelFormentera08 = new Hotel { Id = IdHotelFormentera08, Name = "Hotel F 08", Category = "3*", Description = "Hotel 2º de 3 estrellas en Formentera Only Adults", RegionId = Formentera.Id, HotelTypeId = IdTypeOnlyAdult };
        public static Hotel HotelFormentera09 = new Hotel { Id = IdHotelFormentera09, Name = "Hotel F 09", Category = "4*", Description = "Hotel 2º de 4 estrellas en Formentera Premium", RegionId = Formentera.Id, HotelTypeId = IdTypePremium };
        public static Hotel HotelFormentera10 = new Hotel { Id = IdHotelFormentera10, Name = "Hotel F 10", Category = "5*", Description = "Hotel 2º de 5 estrellas en Formentera Spa", RegionId = Formentera.Id, HotelTypeId = IdTypeHotelSpa };

        public static Guid IdClient01 = Guid.NewGuid();
        public static Guid IdClient02 = Guid.NewGuid();
        public static Guid IdClient03 = Guid.NewGuid();
        public static Guid IdClient04 = Guid.NewGuid();
        public static Guid IdClient05 = Guid.NewGuid();

        public static void InitDDBB()
        {
            OwnLogger.AllLogs.Clear();
            new EmulatedConfig().Clean();

            Mallorca.AddHotel(IdHotelMallorca01);
            Mallorca.AddHotel(IdHotelMallorca02);
            Mallorca.AddHotel(IdHotelMallorca03);
            Mallorca.AddHotel(IdHotelMallorca04);
            Mallorca.AddHotel(IdHotelMallorca05);
            Mallorca.AddHotel(IdHotelMallorca06);
            Mallorca.AddHotel(IdHotelMallorca07);
            Mallorca.AddHotel(IdHotelMallorca08);
            Mallorca.AddHotel(IdHotelMallorca09);
            Mallorca.AddHotel(IdHotelMallorca10);
            Ibiza.AddHotel(IdHotelIbiza01);
            Ibiza.AddHotel(IdHotelIbiza02);
            Ibiza.AddHotel(IdHotelIbiza03);
            Ibiza.AddHotel(IdHotelIbiza04);
            Ibiza.AddHotel(IdHotelIbiza05);
            Ibiza.AddHotel(IdHotelIbiza06);
            Ibiza.AddHotel(IdHotelIbiza07);
            Ibiza.AddHotel(IdHotelIbiza08);
            Ibiza.AddHotel(IdHotelIbiza09);
            Ibiza.AddHotel(IdHotelIbiza10);
            Formentera.AddHotel(IdHotelFormentera01);
            Formentera.AddHotel(IdHotelFormentera02);
            Formentera.AddHotel(IdHotelFormentera03);
            Formentera.AddHotel(IdHotelFormentera04);
            Formentera.AddHotel(IdHotelFormentera05);
            Formentera.AddHotel(IdHotelFormentera06);
            Formentera.AddHotel(IdHotelFormentera07);
            Formentera.AddHotel(IdHotelFormentera08);
            Formentera.AddHotel(IdHotelFormentera09);
            Formentera.AddHotel(IdHotelFormentera10);

            var hotels = new HotelsRepository();
            hotels.Reset();
            hotels.Set(HotelMallorca01);
            hotels.Set(HotelMallorca02);
            hotels.Set(HotelMallorca03);
            hotels.Set(HotelMallorca04);
            hotels.Set(HotelMallorca05);
            hotels.Set(HotelMallorca06);
            hotels.Set(HotelMallorca07);
            hotels.Set(HotelMallorca08);
            hotels.Set(HotelMallorca09);
            hotels.Set(HotelMallorca10);
            hotels.Set(HotelIbiza01);
            hotels.Set(HotelIbiza02);
            hotels.Set(HotelIbiza03);
            hotels.Set(HotelIbiza04);
            hotels.Set(HotelIbiza05);
            hotels.Set(HotelIbiza06);
            hotels.Set(HotelIbiza07);
            hotels.Set(HotelIbiza08);
            hotels.Set(HotelIbiza09);
            hotels.Set(HotelIbiza10);
            hotels.Set(HotelFormentera01);
            hotels.Set(HotelFormentera02);
            hotels.Set(HotelFormentera03);
            hotels.Set(HotelFormentera04);
            hotels.Set(HotelFormentera05);
            hotels.Set(HotelFormentera06);
            hotels.Set(HotelFormentera07);
            hotels.Set(HotelFormentera08);
            hotels.Set(HotelFormentera09);
            hotels.Set(HotelFormentera10);

            var regions = new RegionsRepository();
            regions.Reset();
            regions.Set(Mallorca);
            regions.Set(Ibiza);
            regions.Set(Formentera);

            var types = new HotelTypesRepository();
            types.Reset();
            types.Set(TypeOnlyAdult);
            types.Set(TypeHotelSpa);
            types.Set(TypePremium);

            var clients = new ClientsRepository();
            clients.Reset();
            clients.Set(new Client { Id = IdClient01, Email = "Client01@Email.com", Name = "Client 01", Telephone = "666666601" });
            clients.Get(IdClient01).AddObserver(Mallorca);
            clients.Get(IdClient01).AddObserver(Formentera);
            clients.Get(IdClient01).Preference_A = "Some Value";
            clients.Set(new Client { Id = IdClient02, Email = "Client02@Email.com", Name = "Client 02", Telephone = "666666602" });
            clients.Get(IdClient02).AddObserver(Mallorca);
            clients.Get(IdClient02).AddObserver(Ibiza);
            clients.Get(IdClient02).Preference_A = "Some Value";
            clients.Set(new Client { Id = IdClient03, Email = "Client03@Email.com", Name = "Client 03", Telephone = "666666603" });
            clients.Get(IdClient03).AddObserver(Ibiza);
            clients.Get(IdClient03).AddObserver(Formentera);
            clients.Get(IdClient03).Preference_A = "Some Value";
            clients.Set(new Client { Id = IdClient04, Email = "Client04@Email.com", Name = "Client 04", Telephone = "666666604" });
            clients.Get(IdClient04).AddObserver(Formentera);
            clients.Get(IdClient04).Preference_A = "Some Value";
            clients.Set(new Client { Id = IdClient05, Email = "Client05@Email.com", Name = "Client 05", Telephone = "666666605" });
            clients.Get(IdClient05).AddObserver(Ibiza);
            clients.Get(IdClient05).Preference_A = "Some Value";

            Global.Reset();

            Global.Register<IConfig, EmulatedConfig>();

            Registrator.Register();

            Global.Prepare();
        }
    }
}
