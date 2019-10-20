using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Domain.ClientAggregate;
using Domain.ClientAggregate.Repositories;
using Domain.HotelAggregate;
using Domain.HotelAggregate.Repositories;
using Domain.HotelTypeAggregate;
using Domain.HotelTypeAggregate.Repositories;
using Domain.RegionAggregate;
using Domain.RegionAggregate.Repositories;
using ExternalLibraries.LoggSystem;
using ExternalLibraries.TemplateReaderSystem;
using RecomendedHotelsNotificatorService.Services;

namespace RecomendedHotelsNotificatorService
{
    public class Recomendator : IRecomendator
    {
        private const string BASE_TEMPLATE_PATH = "Templates/RecomendationsMailTemplate.html";
        private const string REGION_TEMPLATE_PATH = "Templates/RecomendationsRegionTemplate.html";

        private const string DEFAULT_EMAIL_SUBJECT = "Your hotels recomendation by Smyrooms";

        private readonly Dictionary<string, string> _templates = new Dictionary<string, string>();

        private readonly ILogger _logger;
        private readonly IClientsRepository _clientsRepository;
        private readonly IRegionsRepository _regionsRepository;
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IHotelTypesRepository _hotelTypesRepository;
        private readonly IMailSenderManager _emialSender;
        private readonly ITemplateReader _templateReader;

        public Recomendator(
            ILogger logger,
            IClientsRepository clientsRepository,
            IRegionsRepository regionsRepository,
            IHotelsRepository hotelsRepository,
            IHotelTypesRepository hotelTypesRepository,
            IMailSenderManager emialSender,
            ITemplateReader templateReader
        ) {
            _logger = logger;
            _clientsRepository = clientsRepository;
            _regionsRepository = regionsRepository;
            _hotelsRepository = hotelsRepository;
            _hotelTypesRepository = hotelTypesRepository;
            _emialSender = emialSender;
            _templateReader = templateReader;
        }

        public void SendRecomendations()
        {
            foreach (var client in GetAllClients())
                SendRecomendation(client);
        }

        private IEnumerable<Client> GetAllClients()
        {
            try
            {
                return _clientsRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.Log($"Impossible to get all clients", e);
            }
            return new List<Client>();
        }

        private void SendRecomendation(Client client)
        {
            if (TryGetTemplate(BASE_TEMPLATE_PATH, out string baseTemplate) && TryGetTemplate(REGION_TEMPLATE_PATH, out string regionTemplate))
                if (TryGenerateClientsEmail(baseTemplate, regionTemplate, client, out string recomendationsEmail))
                    SendEmailToClient(client, recomendationsEmail);
        }

        private void SendEmailToClient(Client client, string recomendationsEmail)
        {
            try
            {
                _emialSender.SendEmail(client.Email, DEFAULT_EMAIL_SUBJECT, recomendationsEmail);
            }
            catch(Exception e)
            {
                _logger.Log($"Impossible to send email to { client.Email }", e);
            }
        }

        private bool TryGenerateClientsEmail(string baseTemplate, string regionTemplate, Client client, out string recomendationsEmail)
        {
            recomendationsEmail = null;

            string regionsBody = string.Empty;

            foreach (var regionId in client.GetAllRegionIds())
                if (TryGetClientRegionBody(regionTemplate, regionId, client, out string regionBody))
                    regionsBody += regionBody;

            if (!string.IsNullOrEmpty(regionsBody))
                recomendationsEmail = baseTemplate
                    .Replace("##_NOMBRE_CLIENTE_##", client.Name)
                    .Replace("##_REGIONS_BLOCK_##", regionsBody);

            return !string.IsNullOrEmpty(recomendationsEmail);
        }

        private bool TryGetClientRegionBody(string regionTemplate, Guid regionId, Client client, out string regionBody)
        {
            regionBody = null;

            string hotelsBody = string.Empty;

            if (TryGetRegion(regionId, out Region region))
                foreach (var hotelId in client.GetAllRegionHotelIds(regionId))
                    if (TryGetHotelBody(hotelId, out string hotelBody))
                        hotelsBody += hotelBody;

            if (!string.IsNullOrEmpty(hotelsBody))
                regionBody = regionTemplate
                    .Replace("##_REGION_NAME_##", region.Name)
                    .Replace("##_REGION_DESCRIPTION_##", region.Description)
                    .Replace("##_HOTELS_BLOCK_##", hotelsBody);

            return !string.IsNullOrEmpty(regionBody);
        }

        private bool TryGetHotelBody(Guid hotelId, out string hotelBody)
        {
            hotelBody = null;

            if (
                TryGetHotel(hotelId, out Hotel hotel)
                && TryGetHotelType(hotel.HotelTypeId, out HotelType type)
                && TryGetTemplate(type.TemplatePath, out string template)
               )
                hotelBody = template
                    .Replace("##_HOTEL_NAME_##", hotel.Name)
                    .Replace("##_HOTEL_CATEGORY_##", hotel.Category)
                    .Replace("##_HOTEL_DESCRIPTION_##", hotel.Description);

            return !string.IsNullOrEmpty(hotelBody);
        }

        private readonly Dictionary<Guid, HotelType> _types = new Dictionary<Guid, HotelType>();
        private bool TryGetHotelType(Guid hotelTypeId, out HotelType type)
        {
            type = null;

            if (_types.ContainsKey(hotelTypeId))
                type = _types[hotelTypeId];

            else
                try
                {
                    type = _hotelTypesRepository.Get(hotelTypeId);
                    _types.Add(hotelTypeId, type);
                }
                catch (Exception e)
                {
                    _logger.Log($"Error getting Hotel Type by Id (Id: { hotelTypeId })", e);
                }

            return type != null;
        }

        private readonly Dictionary<Guid, Hotel> _hotels = new Dictionary<Guid, Hotel>();
        private bool TryGetHotel(Guid hotelId, out Hotel hotel)
        {
            hotel = null;

            if (_hotels.ContainsKey(hotelId))
                hotel = _hotels[hotelId];

            else
                try
                {
                    hotel = _hotelsRepository.Get(hotelId);
                    _hotels.Add(hotelId, hotel);
                }
                catch (Exception e)
                {
                    _logger.Log($"Error getting Hotel by Id (Id: { hotelId })", e);
                }

            return hotel != null;
        }

        private readonly Dictionary<Guid, Region> _regions = new Dictionary<Guid, Region>();
        private bool TryGetRegion(Guid regionId, out Region region)
        {
            region = null;

            if (_regions.ContainsKey(regionId))
                region = _regions[regionId];

            else
                try
                {
                    region = _regionsRepository.Get(regionId);
                    _regions.Add(regionId, region);
                }
                catch(Exception e)
                {
                    _logger.Log($"Error getting Region by Id (Id: { regionId })", e);
                }

            return region != null;
        }

        private bool TryGetTemplate(string path, out string template)
        {
            template = GetTemplate(path);

            return !string.IsNullOrEmpty(template);
        }

        private string GetTemplate(string path)
        {
            string template = null;

            if (_templates.ContainsKey(path))
                return _templates[path];

            try
            {
                template = _templateReader.GetTemplate(path);
                _templates.Add(path, template);
            }
            catch (Exception e)
            {
                _logger.Log($"Error getting template (path: '{ path }')", e);
            }

            return template;
        }
    }
}