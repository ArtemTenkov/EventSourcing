using System.Threading.Tasks;
using Domain.Balance.Events;
using MediatR;

namespace Domain.Balance.Handlers
{
    public class AccountCreatedEventHandler : AsyncNotificationHandler<AccountCreated>
    {        
        protected override async Task HandleCore(AccountCreated notification)
        {
        
        }
    }
}
