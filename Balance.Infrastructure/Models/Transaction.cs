using System;

namespace Balance.Infrastructure.Models
{
    public partial class Transaction
    {
        public Guid Id { get; set; }
        public Guid MerchantId { get; set; }
        public Guid BuyerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionStatusCode { get; set; }
    }
}
