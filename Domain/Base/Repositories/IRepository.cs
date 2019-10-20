using System;
using System.Collections.Generic;

namespace Domain.Base.Repositories
{
    public interface IRepository<T> where T : IAggregate
    {
        void Set(T item);
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Delete(Guid id);
        void Reset();
    }
}
