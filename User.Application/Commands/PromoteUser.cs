using MediatR;
using SharedKernel.Enums;
using SharedKernel.FlowControl;

namespace User.Application.Commands
{
    public class PromoteUser : IRequest<Result>
    {
        public string LastName { get; }
        public PositionType NewPosition { get; }
        public PromoteUser(string lastName, PositionType newPosition)
        {
            LastName = lastName;
            NewPosition = newPosition;
        }
    }
}
