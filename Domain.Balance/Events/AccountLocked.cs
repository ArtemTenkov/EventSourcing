using SharedKernel.Domain;
using System;

namespace Domain.Balance.Events
{
    public class AccountLocked : IDomainEvent
    {
        public Guid AccountId { get; private set; }
        public string Reason { get; private set; }
        public AccountLocked(Guid accountId, string reason)
        {
            AccountId = accountId;
            Reason = reason;
        }
    }
}
