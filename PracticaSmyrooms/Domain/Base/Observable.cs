using System;
using System.Collections.Generic;

namespace PracticaSmyrooms.Domain.Base
{
    public abstract class Observable : Aggregate
    {
        protected void Notify()
        {
            foreach (var observer in _observers)
                observer.Value.Update(this);
        }

        private Dictionary<Guid, IObserver> _observers = new Dictionary<Guid, IObserver>();

        public void AddObserver(IObserver observer)
        {
            if (!_observers.ContainsKey(observer.Id))
                _observers.Add(observer.Id, observer);
        }
    }
}
