using PracticaSmyrooms.Domain.Base;
using PracticaSmyrooms.Domain.ClientAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaSmyrooms.Domain.HotelAggregate
{
    public class Region : Aggregate, IObserver
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private List<Guid> _hotelIds = new List<Guid>();
        public IEnumerable<Guid> HotelIds { get { return _hotelIds; } }

        public void Update(Observable observable)
        {
            if (observable is Client client)
                UpdateClientsOferedHotels(client);
        }

        private void UpdateClientsOferedHotels(Client client)
        {
            client.SetRegionHotelsList(Id, GetRandom());
        }

        private List<Guid> GetRandom()
        {
            List<Guid> result = new List<Guid>();
            
            if (_hotelIds.Count <= 1)
                result = HotelIds.ToList();

            else
            {
                var r = new Random().Next(2);
                for (int i = 0; i < _hotelIds.Count; i++)
                    if (i % 2 == r)
                        result.Add(_hotelIds[i]);
            }

            return result;
        }
    }
}
