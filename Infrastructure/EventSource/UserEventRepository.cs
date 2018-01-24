using Domain.User;
using Infrastructure.Models;
using SharedKernel.Domain;

namespace Infrastructure.EventSource
{
    public class UserEventRepository : EventRepository<UserRoot>
    {
        public UserEventRepository(IAggregateFactory<UserRoot> aggregateFactory, EventSourcingContext dbContext) : base(aggregateFactory, dbContext)
        {
        }
    }
}
