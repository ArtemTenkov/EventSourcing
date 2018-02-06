using SharedKernel.Domain;
using System;

namespace Domain.Balance.Events
{
    public class BalanceDecreased : IDomainEvent
    {
        public Guid TransactionId { get; }
        public decimal Amount { get; }
        public Guid UserId { get; }
        public BalanceDecreased(Guid transactionId, Guid userId, decimal amount)
        {
            TransactionId = transactionId;
            Amount = amount;
            UserId = userId;
        }
    }
}
