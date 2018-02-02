using System.Threading.Tasks;
using MediatR;
using SharedKernel.FlowControl;

namespace User.Application.Commands.Handlers
{
    public class PromoteUserHandler : AsyncRequestHandler<PromoteUser, Result>
    {
        public PromoteUserHandler()
        {

        }
        protected override async Task<Result> HandleCore(PromoteUser command)
        {
            throw new System.NotImplementedException();
        }
    }
}
