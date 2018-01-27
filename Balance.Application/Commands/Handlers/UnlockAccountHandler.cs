using System.Threading.Tasks;
using Domain.Balance;
using MediatR;
using SharedKernel;

namespace Balance.Application.Commands.Handlers
{
    public class UnlockAccountHandler : AsyncRequestHandler<UnlockAccount>
    {
        IEventRepository<AccountRoot> _eventRepository;
        public UnlockAccountHandler(IEventRepository<AccountRoot> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        protected override async Task HandleCore(UnlockAccount command)
        {
            var accountAggregate = _eventRepository.GetById(command.AccountId);
            accountAggregate.UnLock("Unlocked from API");
            await _eventRepository.Save(accountAggregate);
        }
    }
}
