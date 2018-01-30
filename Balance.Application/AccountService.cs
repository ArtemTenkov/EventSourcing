using Balance.Application.Commands;
using Balance.Application.Queries;
using MediatR;
using SharedKernel.DataObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Balance.Application
{
    public interface IAccountService
    {
        Task UnlockAccount(Guid accountId);
        Task<List<TransactionDto>> GetAllTransactions(Guid userId);
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

        public async Task<List<TransactionDto>> GetAllTransactions(Guid userId)
        {
            return await _mediator.Send(new GetTransactionsList(userId));
        }
    }
}
