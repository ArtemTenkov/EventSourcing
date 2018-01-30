using System;

namespace SharedKernel.DataObjects
{
    public class TransactionDto
    {
        public Guid Id { get; }
        public Guid UserId { get; }       
        public decimal Amount { get; }
        public DateTime TransactionDateTime { get; }
        public string TransactionStatusCode { get; }
        public TransactionDto(Guid id, Guid userId, decimal amount, DateTime transactionDateTime, string transactionStatusCode)
        {
            Id = id;
            UserId = userId;
            Amount = amount;
            TransactionDateTime = transactionDateTime;
            TransactionStatusCode = transactionStatusCode;
        }
    }
}
