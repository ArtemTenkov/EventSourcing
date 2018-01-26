using SharedKernel.Domain;
using System;

namespace Domain.Balance.Events
{
    public class AccountVerified : IDomainEvent
    {
        public Guid AccountId { get; private set; }
        public AccountVerified(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
    