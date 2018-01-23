using Domain.Balance.Events;
using SharedKernel.Domain;
using System;

namespace Domain.Balance
{
    public class BalanceRoot : AggregateRoot
    {
        private readonly BalanceState _state;
        internal BalanceRoot(Guid? id = null, BalanceState state = null)
        {
            Id = id.HasValue ? id.Value : Guid.NewGuid();
            _state = state ?? new BalanceState();
        }

        public void Increase(Transaction transaction)
        {
            AddDomainEvent(new BalanceIncreased(transaction.Id, transaction.GetAmount()));
        }

        public void Decrease(Transaction transaction)
        {

        }
    }
}
