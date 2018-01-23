using SharedKernel.Domain;
using SharedKernel.Enums;
using System;

namespace Domain.User.Events
{
    public class UserCreated : IDomainEvent
    {
        public string UserName { get; }
        public string LastName { get; }
        public PositionType Position { get; }
        public Guid AggregateId { get; }
        public UserCreated(string userName, string lastName, 
            Guid aggregateId, PositionType position)
        {
            UserName = userName;
            LastName = lastName;
            Position = position;
            AggregateId = aggregateId;
        }
    }
}
