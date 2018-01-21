using System.Threading.Tasks;
using Application.Commands.Responses;
using Domain.User;
using MediatR;
using SharedKernel;

namespace Application.Commands.Handlers
{
    public class RegisterUserCommandHandler : AsyncRequestHandler<RegisterUser, RegisterUserResponse>
    {
        private IEventRepository<UserRoot> _eventRepository { get; }
        private UserFactory _userFactory { get; }
        public RegisterUserCommandHandler(IEventRepository<UserRoot> eventRepository,
            UserFactory userFactory)
        {
            _eventRepository = eventRepository;
            _userFactory = userFactory;
        }
        protected override async Task<RegisterUserResponse> HandleCore(RegisterUser request)
        {
            var user = _userFactory
                .CreateNew(request.UserName, request.LastName, request.Position);
            await _eventRepository.Save(user);
            return new RegisterUserResponse(string.Empty);
        }
    }
}
