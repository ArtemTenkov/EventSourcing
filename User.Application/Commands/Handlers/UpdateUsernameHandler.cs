using System.Threading.Tasks;
using Domain.User;
using MediatR;
using SharedKernel;
using SharedKernel.Enums;

namespace User.Application.Commands.Handlers
{
    public class UpdateUsernameHandler : AsyncRequestHandler<UpdateUserName, bool>
    {
        IUserRepository _userRepository;
        public UpdateUsernameHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        protected override async Task<bool> HandleCore(UpdateUserName command)
        {
            var userDto = await _userRepository.GetUser(command.LastName.Value);
            if (userDto == null) return false;

            var userRoot = new UserFactory().Restore(userDto.Id, userDto.Name, userDto.LastName, PositionType.NotSet);
            userRoot.UpdateUserName(command.Name);
            await _userRepository.UpdateUser(userRoot.Id, userRoot.UserName.Value);

            return true;
        }
    }
}
