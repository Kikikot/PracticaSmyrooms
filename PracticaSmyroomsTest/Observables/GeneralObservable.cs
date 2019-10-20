using Domain.Base;

namespace PracticaSmyroomsTest.Observables
{
    public class GeneralObservable : Observable
    {
        private string _property;
        public string Property {
            get { return _property; }
            set { if (_property != value) { _property = value; Notify(); } }
        }
    }
}
