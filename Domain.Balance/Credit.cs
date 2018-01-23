using SharedKernel.ValueObjects;
using System;

namespace Domain.Balance
{
    public class Credit : Transaction
    {
        private Credit() { }
        public static Credit Create(Guid userId, Amount amount)
        {
            var credit = new Credit
            {
                UserId = userId,
                Amount = amount ?? throw new ArgumentNullException(nameof(amount))
            };

            return credit;
        }
    }
}
