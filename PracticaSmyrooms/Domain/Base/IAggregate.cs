using System;

namespace PracticaSmyrooms.Domain.Base
{
    public interface IAggregate
    {
        Guid Id { get; set; }
    }
}
