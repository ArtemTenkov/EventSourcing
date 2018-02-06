using JustSaying.Messaging.MessageHandling;
using SharedKernel;
using SharedKernel.DataObjects;
using SharedKernel.Domain.IntegrationEvents;
using SharedKernel.Enums;
using System;
using System.Threading.Tasks;

namespace Balance.Read.Application.Events.Handlers
{
    public class BalanceIncreasedEventHandler : IHandlerAsync<BalanceIncreased>
    {
        IBalanceRepository _repository;
        public BalanceIncreasedEventHandler(IBalanceRepository repository)
        {
            _repository = repository;
        }

        async Task<bool> IHandlerAsync<BalanceIncreased>.Handle(BalanceIncreased @event)
        {
            await _repository.Add(new TransactionDto(@event.TransactionId, @event.UserId,
               @event.Amount, DateTime.Now, TransactionStatusCode.Settled.Value));

            return true;
        }
    }
}
