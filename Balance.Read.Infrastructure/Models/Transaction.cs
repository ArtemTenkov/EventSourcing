using System;

namespace Balance.Read.Infrastructure.Models
{
    public partial class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionStatusCode { get; set; }

        public User User { get; set; }
    }
}
