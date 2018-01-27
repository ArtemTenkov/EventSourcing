using MediatR;
using SharedKernel.ValueObjects;
using System;

namespace User.Application.Commands
{
    public class UpdateUserName : IRequest<bool>
    {
        public Name LastName { get; }
        public Name Name { get; }
        public UpdateUserName(Name lastName, Name name)
        {
            LastName = lastName;
            Name = name;
        }
    }
}
