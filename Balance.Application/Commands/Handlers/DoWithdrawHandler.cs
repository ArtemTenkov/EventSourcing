using System;
using System.Threading.Tasks;
using Domain.Balance;
using MediatR;
using SharedKernel;
using SharedKernel.DataObjects;
using SharedKernel.Enums;
using SharedKernel.FlowControl;
using SharedKernel.ValueObjects;

namespace Balance.Application.Commands.Handlers
{
    public class DoWithdrawHandler : AsyncRequestHandler<DoWithdraw, Result<TransactionDto>>
    {
        IEventRepository<AccountRoot> _eventRepository;
        public DoWithdrawHandler(IEventRepository<AccountRoot> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        protected override async Task<Result<TransactionDto>> HandleCore(DoWithdraw command)
        {
            var accountAggregate = _eventRepository.GetById(command.AccountId);
            var transaction = accountAggregate.Withdraw(Amount.Create(command.Amount));
            await _eventRepository.Save(accountAggregate);

            return Result.Ok(new TransactionDto(transaction.Id, accountAggregate.GetUserGuid, command.Amount, DateTime.Now, TransactionStatusCode.Settled.Value));
        }
    }
}
