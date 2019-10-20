using Domain.Base.Repositories;
using Domain.ClientAggregate;
using Domain.ClientAggregate.Repositories;

namespace RecomendedHotelsNotificatorService.Repositories
{
    public class ClientsRepository : Repository<Client>, IClientsRepository
    {
    }
}
