using System.Threading.Tasks;
using Domain.User.Events;
using MediatR;
using SharedKernel;
using SharedKernel.Domain.SharedEvents;

namespace Domain.User.Handlers
{
    public class UserCreatedEventHandler : AsyncNotificationHandler<UserCreated>
    {
        private IEventRepository<UserRoot> _eventRepository;
        public UserCreatedEventHandler(IEventRepository<UserRoot> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        protected override async Task HandleCore(UserCreated @event)
        {
           //await _eventRepository.Save(new UserRoot(@event.AggregateId, @event.UserName, @event.LastName);
        }
    }
}
