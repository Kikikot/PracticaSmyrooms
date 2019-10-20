using Domain.Base.Repositories;
using Domain.HotelTypeAggregate;
using Domain.HotelTypeAggregate.Repositories;

namespace RecomendedHotelsNotificatorService.Repositories
{
    public class HotelTypesRepository : Repository<HotelType>, IHotelTypesRepository
    {
    }
}
