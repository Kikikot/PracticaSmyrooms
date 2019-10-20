using Domain.Base;
using Domain.ClientAggregate;
using System;
using System.Collections.Generic;

namespace Domain.RegionAggregate
{
    public class Region : Aggregate, IObserver
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private List<Guid> _hotelIds = new List<Guid>();
        public IEnumerable<Guid> HotelIds { get { return _hotelIds; } }

        public void AddHotel(Guid hotelId)
        {
            if (!_hotelIds.Contains(hotelId))
                _hotelIds.Add(hotelId);
        }

        public void Update(Observable observable)
        {
            if (observable is Client client)
                UpdateClientsOferedHotels(client);
        }

        private void UpdateClientsOferedHotels(Client client)
        {
            client.SetRegionHotelsList(Id, GetXRandomHotels(3));
        }

        private List<Guid> GetXRandomHotels(int x)
        {
            int variant = 3;

            List<Guid> result = new List<Guid>();

            var r = new Random().Next(variant);
            for (int i = 0; i < _hotelIds.Count && result.Count < x; i++)
                if (i % variant == r)
                    result.Add(_hotelIds[i]);

            return result;
        }
    }
}
