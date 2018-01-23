using SharedKernel.ValueObjects;
using System;

namespace SharedKernel.DataObjects
{
    public class UserDto
    {
        public Guid Id { get; }
        public Name Name { get; }
        public Name LastName { get; }
        public UserDto(Guid id, Name name, Name lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;            
        }
    }
}
