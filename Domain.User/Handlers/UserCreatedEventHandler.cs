using System.Threading.Tasks;
using Domain.User.Events;
using MediatR;
using SharedKernel;

namespace Domain.User.Handlers
{
    public class UserCreatedEventHandler : AsyncNotificationHandler<UserCreated>
    {
        private IRdbmsRepository _rdbmsRepository;
        public UserCreatedEventHandler(IRdbmsRepository rdbmsRepository)
        {
            _rdbmsRepository = rdbmsRepository;
        }
        protected override async Task HandleCore(UserCreated @event)
        {
           await _rdbmsRepository.AddUser(@event.AggregateId, @event.UserName, @event.LastName);
        }
    }
}
