using Domain.User;
using SharedKernel.Domain;
using User.Infrastructure.Models;

namespace User.Infrastructure.EventSource
{
    public class UserEventRepository : EventRepository<UserRoot>
    {
        public UserEventRepository(IAggregateFactory<UserRoot> aggregateFactory, EventSourcingContext dbContext) : base(aggregateFactory, dbContext)
        {
        }
    }
}
