using System.Threading.Tasks;
using Domain.User;
using MediatR;
using SharedKernel;

namespace Application.Commands.Handlers
{
    public class UpdateUsernameHandler : AsyncRequestHandler<UpdateUserName, bool>
    {
        IEventRepository<UserRoot> _eventRepository;
        public UpdateUsernameHandler(IEventRepository<UserRoot> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        protected override async Task<bool> HandleCore(UpdateUserName request)
        {
            var userRoot = _eventRepository.GetById(request.AggregateId);
            if (userRoot == null) return false;

            userRoot.UpdateUserName(request.Name);
            await _eventRepository.Save(userRoot);

            return true;
        }
    }
}
