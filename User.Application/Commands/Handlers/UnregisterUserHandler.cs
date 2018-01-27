using System;
using System.Threading.Tasks;
using Domain.User;
using MediatR;
using SharedKernel;
using SharedKernel.Enums;

namespace User.Application.Commands.Handlers
{
    public class UnregisterUserHandler : AsyncRequestHandler<UnregisterUser, Guid>
    {
        private IUserRepository _userRepository;
        private UserFactory _userFactory;
        private IUserDomainService _userService;
        public UnregisterUserHandler(IUserRepository userRepository, UserFactory userFactory, IUserDomainService userService)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
            _userService = userService;
        }

        protected override async Task<Guid> HandleCore(UnregisterUser command)
        {
            var userDto = await _userRepository.GetUser(command.LastName);
            var userRoot = _userFactory.Restore(userDto.Id, userDto.Name, userDto.LastName, PositionType.NotSet);
            var deletionResult = _userService.DeleteUser(userRoot);

            if (deletionResult.IsSuccess)
                return userDto.Id;

            return Guid.Empty;
        }
    }
}
