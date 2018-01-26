using Domain.Balance;
using Infrastructure.Models;
using SharedKernel.Domain;

namespace Infrastructure.EventSource
{
    public class AccountEventRepository : EventRepository<AccountRoot>
    {
        public AccountEventRepository(IAggregateFactory<AccountRoot> aggregateFactory, EventSourcingContext dbContext) : base(aggregateFactory, dbContext)
        {
        }
    }
}
