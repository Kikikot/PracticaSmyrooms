using System;

namespace PracticaSmyrooms.Domain.Base
{
    public class Aggregate : IAggregate
    {
        public Guid Id { get; set; }
    }
}
