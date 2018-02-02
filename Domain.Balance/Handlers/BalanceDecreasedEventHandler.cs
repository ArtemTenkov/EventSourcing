using System.Threading.Tasks;
using Domain.Balance.Events;
using MediatR;

namespace Domain.Balance.Handlers
{
    public class BalanceDecreasedEventHandler : AsyncNotificationHandler<BalanceDecreased>
    {
        protected override async Task HandleCore(BalanceDecreased notification)
        {
            
        }
    }
}
