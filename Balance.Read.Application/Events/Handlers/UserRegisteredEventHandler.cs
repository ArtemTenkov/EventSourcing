using JustSaying.Messaging.MessageHandling;
using SharedKernel;
using SharedKernel.DataObjects;
using SharedKernel.Domain.IntegrationEvents;
using SharedKernel.Enums;
using System;
using System.Threading.Tasks;

namespace Balance.Read.Application.Events.Handlers
{
    public class UserRegisteredEventHandler : IHandlerAsync<UserRegistered>
    {
        IBalanceRepository _balanceRepository;
        public UserRegisteredEventHandler(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public async Task<bool> Handle(UserRegistered @event)
        {
            var transactionDto = new TransactionDto(Guid.NewGuid(), @event.UserId, 0, 
                DateTime.Now, TransactionStatusCode.NotSet.Value);
            await _balanceRepository.Add(transactionDto);

            return true;
        }
    }
}
