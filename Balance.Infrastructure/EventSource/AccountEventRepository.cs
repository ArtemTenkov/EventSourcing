using Balance.Infrastructure.Models;
using Domain.Balance;
using SharedKernel.Domain;

namespace Balance.Infrastructure.EventSource
{
    public class AccountEventRepository : EventRepository<AccountRoot>
    {
        public AccountEventRepository(IAggregateFactory<AccountRoot> aggregateFactory, EventSourcingContext dbContext) : base(aggregateFactory, dbContext)
        {
        }
    }
}
