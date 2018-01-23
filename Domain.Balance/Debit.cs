using SharedKernel.ValueObjects;
using System;

namespace Domain.Balance
{
    public class Debit : Transaction
    {
        private Debit() { }

        public static Debit Create(Guid userId, Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            var debit = new Debit
            {
                UserId = userId,
                Amount = amount
            };

            return debit;
        }
    }
}

