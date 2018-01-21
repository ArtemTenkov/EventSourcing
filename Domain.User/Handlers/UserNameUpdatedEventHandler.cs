using System.Threading.Tasks;
using Domain.User.Events;
using MediatR;
using SharedKernel;

namespace Domain.User.Handlers
{
    public class UserNameUpdatedEventHandler : AsyncNotificationHandler<UserNameUpdated>
    {
        private IRdbmsRepository _repo;
        public UserNameUpdatedEventHandler(IRdbmsRepository repo)
        {
            _repo = repo;
        }
        protected override async Task HandleCore(UserNameUpdated @event)
        {
           await _repo.UpdateUser(@event.AggregateId, @event.NewName);
        }
    }
}
