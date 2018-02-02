using System.Threading.Tasks;
using Domain.Balance;
using MediatR;
using SharedKernel;
using SharedKernel.FlowControl;
using SharedKernel.ValueObjects;

namespace Balance.Application.Commands.Handlers
{
    public class DoWithdrawHandler : AsyncRequestHandler<DoWithdraw, Result>
    {
        IEventRepository<AccountRoot> _eventRepository;
        public DoWithdrawHandler(IEventRepository<AccountRoot> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        protected override async Task<Result> HandleCore(DoWithdraw command)
        {
            var accountAggregate = _eventRepository.GetById(command.AccountId);
            accountAggregate.Withdraw(Amount.Create(command.Amount));
            await _eventRepository.Save(accountAggregate);

            return Result.Ok();
        }
    }
}
