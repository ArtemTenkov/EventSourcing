using SharedKernel.Domain;
using System;
using System.Threading.Tasks;

namespace SharedKernel
{
    public interface IEventRepository<T>
    {
        T GetById(Guid id);
        Task Save(AggregateRoot aggregate);
    }
}
