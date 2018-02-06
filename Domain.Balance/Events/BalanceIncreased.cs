using SharedKernel.Domain;
using SharedKernel.ValueObjects;
using System;

namespace Domain.Balance.Events
{
    public class BalanceIncreased : IDomainEvent
    {
        public Guid TransactionId { get; }
        public decimal Amount { get; }
        public Guid UserId { get; }
        public BalanceIncreased(Guid transactionId, Guid userId, decimal amount)
        {
            TransactionId = transactionId;
            Amount = amount;
            UserId = userId;
        }
    }
}
