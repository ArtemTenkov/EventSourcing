using System.Threading.Tasks;
using JustSaying.Messaging.MessageHandling;
using SharedKernel;
using SharedKernel.Domain.IntegrationEvents;

namespace Domain.Balance.Handlers
{
    public class UserRegisteredEventHandler : IHandlerAsync<UserRegistered>
    {
        IEventRepository<AccountRoot> _repository;
        public UserRegisteredEventHandler(IEventRepository<AccountRoot> repository)
        {
            _repository = repository;           
        }

        public async Task<bool> Handle(UserRegistered @event)
        {
            var balanceRoot = new AccountFactory()
                .CreateNewBalance(@event.UserId);
            await _repository.Save(balanceRoot);

            return true;
        }       
    }
}
