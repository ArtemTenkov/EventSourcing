using JustSaying.Models;
using System;

namespace SharedKernel.Domain.IntegrationEvents
{
    public class BalanceDecreased : Message, IIntegrationEvent
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
