using System;
using System.Collections.Generic;

namespace SharedKernel.Domain
{
    public interface IAggregateFactory<T>
    {
        T RestoreBalance(Guid id, IEnumerable<object> events = null);
    }
}
