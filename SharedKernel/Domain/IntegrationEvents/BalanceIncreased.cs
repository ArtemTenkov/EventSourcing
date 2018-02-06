using JustSaying.Models;
using System;

namespace SharedKernel.Domain.IntegrationEvents
{
    public class BalanceIncreased : Message, IIntegrationEvent
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
