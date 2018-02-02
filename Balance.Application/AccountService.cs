using Balance.Application.Commands;
using Balance.Application.Queries;
using MediatR;
using SharedKernel.DataObjects;
using SharedKernel.FlowControl;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Balance.Application
{
    public interface IAccountService
    {
        Task UnlockAccount(Guid accountId);
        Task<List<TransactionDto>> GetAllTransactions(Guid userId);
        Task<Dictionary<Guid, Amount>> GetAllAccountIds();
        Task<Result> Deposit(Guid accountId, decimal amount);
        Task<Result> Withdraw(Guid accountId, decimal amount);
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

        public async Task<Result> Deposit(Guid accountId, decimal amount)
        {
            return await _mediator.Send(new DoDeposit(accountId, Amount.Create(amount).Value));
        }

        public async Task<Result> Withdraw(Guid accountId, decimal amount)
        {
            return await _mediator.Send(new DoWithdraw(accountId, amount));
        }

        public async Task<Dictionary<Guid, Amount>> GetAllAccountIds()
        {
            return await _mediator.Send(new GetAllAccounts());
        }
    }
}
