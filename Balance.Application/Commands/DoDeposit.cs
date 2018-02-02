using MediatR;
using SharedKernel.FlowControl;
using SharedKernel.ValueObjects;
using System;

namespace Balance.Application.Commands
{
    public class DoDeposit : IRequest<Result>
    {
        public Guid AccountId { get; }
        public decimal Amount { get; }
        public DoDeposit(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
