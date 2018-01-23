using Domain.User;
using Infrastructure.Models;
using SharedKernel.Domain;

namespace Infrastructure.EventSource
{
    public class UserRepository : EventRepository<UserRoot>
    {
        public UserRepository(IAggregateFactory<UserRoot> aggregateFactory, EventSourcingContext dbContext) : base(aggregateFactory, dbContext)
        {
        }
    }
}
