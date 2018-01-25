using System.Threading.Tasks;
using Application.Commands.Responses;
using Domain.User;
using MediatR;
using SharedKernel;

namespace Application.Commands.Handlers
{
    //NB! Once the user registered - create account
    public class RegisterUserCommandHandler : AsyncRequestHandler<RegisterUser, RegisterUserResponse>
    {
        private IUserRepository _userRepository { get; }
        private UserFactory _userFactory { get; }
        public RegisterUserCommandHandler(IUserRepository userRepository,
            UserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }
        protected override async Task<RegisterUserResponse> HandleCore(RegisterUser request)
        {
            var user = _userFactory
                .CreateNew(request.UserName, request.LastName, request.Position);
            await _userRepository.AddUser(user.Id, user.UserName.Value, user.LastName.Value);

            return new RegisterUserResponse(string.Empty);
        }
    }   
}
