using SharedKernel.Domain;
using SharedKernel.ValueObjects;
using System;

namespace Domain.Balance.Events
{
    public class BalanceIncreased : IDomainEvent
    {
        public Guid TransactionId { get; }
        public Amount Amount { get; }
        public BalanceIncreased(Guid transactionId, Amount amount)
        {
            TransactionId = transactionId;
            Amount = amount;
        }
    }
}
