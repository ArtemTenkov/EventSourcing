using System;
using System.Threading.Tasks;
using Domain.User;
using MediatR;
using SharedKernel;
using SharedKernel.FlowControl;

namespace User.Application.Commands.Handlers
{
    //NB! Once the user registered - create account
    public class RegisterUserHandler : AsyncRequestHandler<RegisterUser, Result<Guid>>
    {
        private IUserRepository _userRepository { get; }
        private UserFactory _userFactory { get; }
        public RegisterUserHandler(IUserRepository userRepository,
            UserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }
        protected override async Task<Result<Guid>> HandleCore(RegisterUser command)
        {
            var user = _userFactory
                .CreateNew(command.UserName, command.LastName, command.Position);
            await _userRepository.AddUser(user.Id, user.UserName.Value, user.LastName.Value);

            return Result.Ok(user.Id);
        }
    }   
}
