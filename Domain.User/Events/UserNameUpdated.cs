using SharedKernel.Domain;
using System;

namespace Domain.User.Events
{
    public class UserNameUpdated : IDomainEvent
    {
        public string NewName { get; }      
        public Guid AggregateId { get; }
        public UserNameUpdated(string newName, Guid aggregateId)
        {
            NewName = newName;            
            AggregateId = aggregateId;
        }
    }
}
