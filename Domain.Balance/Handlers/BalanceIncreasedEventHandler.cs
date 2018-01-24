using System.Threading.Tasks;
using Domain.Balance.Events;
using MediatR;
using SharedKernel;

namespace Domain.Balance.Handlers
{
    public class BalanceIncreasedEventHandler : AsyncNotificationHandler<BalanceIncreased>
    {
        IEventRepository<AccountRoot> _repository;
        public BalanceIncreasedEventHandler(IEventRepository<AccountRoot> repository)
        {
            _repository = repository;
        }
        protected override async Task HandleCore(BalanceIncreased @event)
        {
            var balanceAggregate = _repository.GetById(@event.TransactionId);
            //balanceAggregate.
        }
    }
}
