using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel
{
    public interface IEventRepository<T>
    {
        T GetById(Guid id);
        IEnumerable<T> GetAggregates();
        Task Save(AggregateRoot aggregate);
    }
}
