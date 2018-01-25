using Application.Commands;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Application
{
    public interface IAccountService
    {
        Task UnlockAccount(Guid accountId);
    }
    public class AccountService : IAccountService
    {
        IMediator _mediator;
        public AccountService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task UnlockAccount(Guid accountId)
        {
            await _mediator.Send(new UnlockAccount(accountId));
        }
    }
}
