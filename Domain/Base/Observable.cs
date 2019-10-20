using System;
using System.Collections.Generic;

namespace Domain.Base
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
            if (observer != null && !_observers.ContainsKey(observer.Id))
                _observers.Add(observer.Id, observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observer != null && _observers.ContainsKey(observer.Id))
                _observers.Remove(observer.Id);
        }
    }
}
