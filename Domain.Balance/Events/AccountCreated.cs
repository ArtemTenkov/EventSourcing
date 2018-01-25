using SharedKernel.Domain;
using System;

namespace Domain.Balance.Events
{
    public class AccountCreated : IDomainEvent
    {
        public Guid UserId { get; private set; }
        public DateTime CreationDateTime { get; private set; }
        public AccountCreated(Guid userId)
        {
            UserId = userId;
        }
    }
}
