using Domain.Balance.Events;
using SharedKernel;
using SharedKernel.Domain;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Balance
{
    public class AccountState : StateBase
    {
        public Guid UserGuid { get; private set; }
        public AccountStatus AccountStatus { get; private set; } = AccountStatus.NotSet;
        public Amount Amount { get; private set; } = Amount.NotSet;
        public List<Transaction> Transactions { get; private set; } = new List<Transaction>();

        public void SetState(AccountStatus status) => AccountStatus = status;
        public override void Modify(object @event) =>
            RedirectToWhen.InvokeEventOptional(this, @event);

        public void When(AccountCreated @event)
        {
            UserGuid = @event.UserId;
            AccountStatus = AccountStatus.Pending;
        }

        public void When(AccountVerified @event)
        {
            AccountStatus = AccountStatus.Active;
        }

        public void When(AccountLocked @event)
        {
            AccountStatus = AccountStatus.Locked;
        }

        public void When(AccountUnlocked @event)
        {
            AccountStatus = AccountStatus.Active;
        }

        public void When(BalanceIncreased @event)
        {
            var amount = Amount.Create(@event.Amount);
            this.Transactions.Add(new Transaction(UserGuid, amount, DateTime.Now, TransactionStatusCode.Settled));
            this.Amount += amount;
        }

        public void When(BalanceDecreased @event)
        {
            var amount = Amount.Create(@event.Amount);
            this.Transactions.Add(new Transaction(UserGuid, amount, DateTime.Now, TransactionStatusCode.Settled));
            this.Amount -= amount;
        }

        public AccountState(IEnumerable<object> events = null)
            : base(events) { }
    }
}
