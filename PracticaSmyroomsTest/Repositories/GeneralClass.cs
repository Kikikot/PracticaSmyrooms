using Domain.Base;
using Domain.Base.Repositories;

namespace PracticaSmyroomsTest.Repositories
{
    public class GeneralClass : Aggregate
    {
        public string Name { get; set; }
    }

    public interface IGeneralRepository : IRepository<GeneralClass> {}

    public class GeneralRepository : Repository<GeneralClass> , IGeneralRepository { }
}
