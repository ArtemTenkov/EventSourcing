using Domain.User.Events;
using SharedKernel.Domain;
using SharedKernel.Domain.SharedEvents;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;
using System;

namespace Domain.User
{
    public class UserRoot : AggregateRoot
    {
        public Name UserName { get; private set; }
        public Name LastName { get; private set; }
        public PositionType Position { get; private set; }
        
        internal UserRoot(Guid? id = null)
        {
            Id = id.HasValue? id.Value: Guid.NewGuid();            
        }

        internal void Initialize(string userName, string lastName, PositionType position)
        {
            UserName = Name.Create(userName);
            LastName = Name.Create(lastName);
            Position = position;

            AddDomainEvent(new UserCreated(userName, lastName, this.Id, position));
        }

        public void UpdateUserName(Name name)
        {
            UserName = name;
            AddDomainEvent(new UserNameUpdated(name.Value, this.Id));
        }       
    }
}
