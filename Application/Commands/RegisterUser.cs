using MediatR;
using SharedKernel.Enums;
using SharedKernel.FlowControl;
using System;

namespace Application.Commands
{
    public class RegisterUser : IRequest<Result<Guid>>
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
