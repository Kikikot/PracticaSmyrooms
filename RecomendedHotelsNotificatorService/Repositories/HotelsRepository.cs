using Domain.Base.Repositories;
using Domain.HotelAggregate;
using Domain.HotelAggregate.Repositories;

namespace RecomendedHotelsNotificatorService.Repositories
{
    public class HotelsRepository : Repository<Hotel>, IHotelsRepository
    {
    }
}
