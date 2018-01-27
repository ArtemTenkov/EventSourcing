using MediatR;
using System;

namespace User.Application.Commands
{
    public class UnregisterUser : IRequest<Guid>
    {       
        public string LastName { get; }     
        public UnregisterUser(string lastName)
        {            
            LastName = lastName;         
        }
    }
}
