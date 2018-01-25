using SharedKernel.Domain;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;
using System;

namespace Domain.Balance
{
    public class Transaction : Entity
    {
        private Guid _accountOwnerId;        
        private Amount _amount;
        private DateTime _transactionDateTime;
        private TransactionStatusCode _transactionStatus;

        internal Guid GetAccountOwnerId => _accountOwnerId;        
        internal Amount GetAmount => _amount;
        internal DateTime GetTransactionDateTime => _transactionDateTime;
        internal TransactionStatusCode GetTransactionStatusCode => _transactionStatus;
        internal void SetTransactionStatus(TransactionStatusCode code)
        {
            _transactionStatus = code;
        }
        internal Transaction(Guid accountOwnerId, Amount amount, DateTime transactionDateTime, TransactionStatusCode transactionStatus)
        {
            Id = Guid.NewGuid();
            _accountOwnerId = accountOwnerId;            
            _amount = amount;
            _transactionDateTime = transactionDateTime;
            _transactionStatus = transactionStatus;
        }
    }
}
