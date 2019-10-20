using System;

namespace Domain.Base
{
    public interface IAggregate
    {
        Guid Id { get; set; }
    }
}
