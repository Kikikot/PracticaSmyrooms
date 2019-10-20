using System;
using System.Collections.Generic;

namespace Domain.Base.Repositories
{
    public class Repository<T> : IRepository<T> where T : IAggregate
    {
        private static Dictionary<Guid, T> _repository = new Dictionary<Guid, T>();

        public void Set(T item)
        {
            if (item == null)
                return;

            if (_repository.ContainsKey(item.Id))
                _repository[item.Id] = item;

            else
                _repository.Add(item.Id, item);
        }

        public T Get(Guid id)
        {
            T item = default(T);

            if (_repository.ContainsKey(id))
                item = _repository[id];

            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.Values;
        }

        public void Delete(Guid id)
        {
            if (_repository.ContainsKey(id))
                _repository.Remove(id);
        }

        public void Reset()
        {
            _repository = new Dictionary<Guid, T>();
        }
    }
}
