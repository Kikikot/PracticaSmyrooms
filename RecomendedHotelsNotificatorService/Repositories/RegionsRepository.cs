using Domain.Base.Repositories;
using Domain.RegionAggregate;
using Domain.RegionAggregate.Repositories;

namespace RecomendedHotelsNotificatorService.Repositories
{
    public class RegionsRepository : Repository<Region>, IRegionsRepository
    {
    }
}
