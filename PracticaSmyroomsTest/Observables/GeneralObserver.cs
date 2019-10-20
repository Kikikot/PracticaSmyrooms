using Domain.Base;
using System;

namespace PracticaSmyroomsTest.Observables
{
    public class GeneralObserver : IObserver
    {
        public Guid Id { get; set; }

        public int Count = 0;

        public void Update(Observable observable)
        {
            Count++;
        }
    }
}
