using System.Threading.Tasks;
using JustSaying.Messaging.MessageHandling;
using SharedKernel.Domain.IntegrationEvents;

namespace Balance.Read.Application.Events.Handlers
{
    public class BalanceDecreasedEventHandler : IHandlerAsync<BalanceDecreased>
    {
        public async Task<bool> Handle(BalanceDecreased message)
        {
            return true;
        }
    }
}
