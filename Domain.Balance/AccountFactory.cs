using System;
using System.Collections.Generic;
using SharedKernel.Domain;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;

namespace Domain.Balance
{
    public class AccountFactory : IAggregateFactory<AccountRoot>
    {
        public AggregateRoot CreateNewBalance()
        {
            var balance = new AccountRoot();
            balance.Initialize();
            return balance;
        }

        public AccountRoot RestoreBalance(Guid id, IEnumerable<object> events = null)
        {
            var aggregate = new AccountRoot(id, new AccountState(events));
            return aggregate;
        }

        public Transaction CreateTransaction(Guid accountOwnerId, Amount amount)
        {
            return new Transaction(accountOwnerId, amount, DateTime.Now, TransactionStatusCode.Processing);
        }
    }
}
