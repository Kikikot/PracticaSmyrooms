using System;

namespace Domain.Base
{
    public abstract class Aggregate : IAggregate
    {
        public Guid Id { get; set; }
    }
}
