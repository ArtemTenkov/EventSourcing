﻿using MediatR;
using SharedKernel.FlowControl;
using System;

namespace Balance.Application.Commands
{
    public class DoWithdraw : IRequest<Result>
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
    