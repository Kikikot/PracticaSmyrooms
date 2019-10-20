using Domain.Base;

namespace Domain.HotelTypeAggregate
{
    public class HotelType : Aggregate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplatePath { get; set; }
    }
}
