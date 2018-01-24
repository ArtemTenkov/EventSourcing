using Domain.Balance.Events;
using SharedKernel.Domain;
using SharedKernel.ValueObjects;
using System;

namespace Domain.Balance
{
    public class AccountRoot : AggregateRoot
    {
        private readonly AccountState _state;
        internal AccountRoot(Guid? id = null, AccountState state = null)
        {
            Id = id.HasValue ? id.Value : Guid.NewGuid();
            _state = state ?? new AccountState();
        }

        //Replace with arguments: user, buyer, 
        public void Withdraw(Amount amount)
        {
            var transaction = new AccountFactory().CreateTransaction(Id, amount);
        }

        public void Deposit(Amount amount)
        {
            //Transaction entity should isolate appropriate logic and validation
            var transaction = new AccountFactory().CreateTransaction(Id, amount);
            AddDomainEvent(new BalanceIncreased(transaction.Id, transaction.GetAmount));
        }
    }
}
