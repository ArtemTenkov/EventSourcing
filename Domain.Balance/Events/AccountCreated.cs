using SharedKernel.Domain;
using System;

namespace Domain.Balance.Events
{
    public class AccountCreated : IDomainEvent
    {
        public Guid UserId { get; }
        public Guid AccountId { get; }
        public DateTime CreationDateTime { get; private set; }
        public AccountCreated(Guid userId, Guid accountId, DateTime creationDateTime)
        {
            UserId = userId;
            CreationDateTime = creationDateTime;
            AccountId = accountId;
        }
    }
}
