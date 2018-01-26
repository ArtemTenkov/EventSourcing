using MediatR;
using System;

namespace Application.Commands
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
