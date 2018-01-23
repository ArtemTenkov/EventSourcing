using SharedKernel.Domain;
using SharedKernel.ValueObjects;
using System;

namespace Domain.Balance
{
    public class Transaction : Entity
    {
        protected Guid UserId;
        protected Amount Amount;

        public Guid GetUserId()
        {
            return UserId;
        }

        public Amount GetAmount()
        {
            return Amount;
        }

        protected Transaction()
        {

        }
    }
}
