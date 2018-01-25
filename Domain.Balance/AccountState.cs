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
        public AccountStatus AccountStatus { get; private set; }
        public Amount Amount { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public void SetState(AccountStatus status) => AccountStatus = status;
        public override void Modify(object @event) =>
            RedirectToWhen.InvokeEventOptional(this, @event);

        public void When(AccountCreated @event)
        {
            UserGuid = @event.UserId;
            AccountStatus = AccountStatus.Pending;
        }

        public void When(BalanceIncreased @event)
        {

        }

        public void When(BalanceDecreased @event)
        {

        }

        public AccountState(IEnumerable<object> events = null)
            : base(events) { }
    }
}
