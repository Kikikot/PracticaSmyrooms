using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.ClientAggregate
{
    public class Client : Observable
    {
        private string[] _info = new string[6];
        public string Name { get { return _info[0]; } set { _setInfo(0, value); } }
        public string Email { get { return _info[1]; } set { _setInfo(1, value); } }
        public string Telephone { get { return _info[2]; } set { _setInfo(2, value); } }
        public string Preference_A { get { return _info[3]; } set { _setInfo(3, value); } }
        public string Preference_B { get { return _info[4]; } set { _setInfo(4, value); } }
        public string Preference_C { get { return _info[5]; } set { _setInfo(5, value); } }

        private void _setInfo(int index, string value)
        {
            if (_info[index] != value)
            {
                _info[index] = value;
                Notify();
            }
        }

        public Dictionary<Guid, List<Guid>> _hotelIdsByRegionId = new Dictionary<Guid, List<Guid>>();
        public void SetRegionHotelsList(Guid areaId, List<Guid> hotelIds)
        {
            if (hotelIds == null)
            {
                if (_hotelIdsByRegionId.ContainsKey(areaId))
                    _hotelIdsByRegionId.Remove(areaId);
            }
            else
            {
                if (!_hotelIdsByRegionId.ContainsKey(areaId))
                    _hotelIdsByRegionId.Add(areaId, hotelIds);

                else
                    _hotelIdsByRegionId[areaId] = hotelIds;
            }
        }

        public IEnumerable<Guid> GetAllRegionIds()
        {
            return _hotelIdsByRegionId.Keys;
        }

        public IEnumerable<Guid> GetAllRegionHotelIds(Guid regionId)
        {
            if (_hotelIdsByRegionId.ContainsKey(regionId))
                return _hotelIdsByRegionId[regionId];

            return new List<Guid>();
        }
    }
}
