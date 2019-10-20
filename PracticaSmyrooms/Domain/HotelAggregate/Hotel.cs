using PracticaSmyrooms.Domain.Base;
using System;

namespace PracticaSmyrooms.Domain.HotelAggregate
{
    public class Hotel : Aggregate
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid AreaId { get; set; }
        public Guid HotelTypeId { get; set; }
    }
}
