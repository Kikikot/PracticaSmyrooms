namespace PracticaSmyrooms.Domain.Base
{
    public interface IObserver : IAggregate
    {
        void Update(Observable observable);
    }
}