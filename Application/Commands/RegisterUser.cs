using Application.Commands.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Application.Commands
{
    public class RegisterUser : IRequest<RegisterUserResponse>
    {
        public string UserName { get; }
        public string LastName { get; }
        public PositionType Position { get; }
        public RegisterUser(string userName, string lastName, PositionType position)
        {
            UserName = userName;
            LastName = lastName;
            Position = position;
        }
    }
}
