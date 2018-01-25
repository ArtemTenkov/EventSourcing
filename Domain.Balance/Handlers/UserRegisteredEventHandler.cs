using System.Threading.Tasks;
using MediatR;
using SharedKernel;
using SharedKernel.Domain.IntegrationEvents;

namespace Domain.Balance.Handlers
{
    public class UserRegisteredEventHandler : AsyncNotificationHandler<UserRegistered>
    {
        IEventRepository<AccountRoot> _repository;
        public UserRegisteredEventHandler(IEventRepository<AccountRoot> repository)
        {
            _repository = repository;
        }
        protected override async Task HandleCore(UserRegistered notification)
        {
            var balanceRoot = new AccountFactory().CreateNewBalance();
            await _repository.Save(balanceRoot);
        }
    }
}
