using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Handlers
{
    public class UnregisterUserHandler : AsyncRequestHandler<UnregisterUser, bool>
    {
        protected override async Task<bool> HandleCore(UnregisterUser command)
        {
            throw new System.NotImplementedException();
        }
    }
}
