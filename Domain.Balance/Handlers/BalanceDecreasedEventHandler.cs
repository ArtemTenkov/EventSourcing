using System.Threading.Tasks;
using Domain.Balance.Events;
using MediatR;

namespace Domain.Balance.Handlers
{
    public class BalanceDecreasedEventHandler : AsyncNotificationHandler<BalanceDecreased>
    {
        protected override Task HandleCore(BalanceDecreased notification)
        {
            throw new System.NotImplementedException();
        }
    }
}
