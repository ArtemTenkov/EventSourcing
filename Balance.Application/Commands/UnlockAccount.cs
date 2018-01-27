using MediatR;
using System;

namespace Balance.Application.Commands
{
    public class UnlockAccount : IRequest
    {
        public Guid AccountId { get; private set; }
        public UnlockAccount(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
