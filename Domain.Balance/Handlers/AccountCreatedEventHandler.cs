using System;
using System.Threading.Tasks;
using Domain.Balance.Events;
using MediatR;
using SharedKernel;
using SharedKernel.DataObjects;
using SharedKernel.Enums;

namespace Domain.Balance.Handlers
{
    public class AccountCreatedEventHandler : AsyncNotificationHandler<AccountCreated>
    {
        IBalanceRepository _balanceRepository;
        public AccountCreatedEventHandler(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }
        protected override async Task HandleCore(AccountCreated notification)
        {
            var transactionDto = new TransactionDto(Guid.NewGuid(), notification.UserId, 0, notification.CreationDateTime, TransactionStatusCode.NotSet.Value);
           await _balanceRepository.Add(transactionDto);
        }
    }
}
