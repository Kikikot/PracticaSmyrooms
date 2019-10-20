using Domain.Base;
using System;

namespace Domain.HotelAggregate
{
    public class Hotel : Aggregate
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid RegionId { get; set; }
        public Guid HotelTypeId { get; set; }
    }
}
