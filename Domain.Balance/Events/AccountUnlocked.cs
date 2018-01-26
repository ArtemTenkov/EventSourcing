using SharedKernel.Domain;
using System;

namespace Domain.Balance.Events
{
    public class AccountUnlocked : IDomainEvent
    {
        public Guid AccountId { get; private set; }
        public string Reason { get; private set; }
        public AccountUnlocked(Guid accountId, string reason)
        {
            AccountId = accountId;
            Reason = reason;
        }
    }
}
