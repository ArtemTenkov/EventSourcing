using MediatR;
using SharedKernel.DataObjects;
using SharedKernel.FlowControl;
using System;

namespace Balance.Application.Commands
{
    public class DoWithdraw : IRequest<Result<TransactionDto>>
    {
        public Guid AccountId { get; }
        public decimal Amount { get; }
        public DoWithdraw(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
    