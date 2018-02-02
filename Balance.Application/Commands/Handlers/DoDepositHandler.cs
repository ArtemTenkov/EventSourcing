using System.Threading.Tasks;
using Domain.Balance;
using MediatR;
using SharedKernel;
using SharedKernel.FlowControl;
using SharedKernel.ValueObjects;

namespace Balance.Application.Commands.Handlers
{
    public class DoDepositHandler : AsyncRequestHandler<DoDeposit, Result>
    {
        IEventRepository<AccountRoot> _eventRepository;
        public DoDepositHandler(IEventRepository<AccountRoot> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        protected override async Task<Result> HandleCore(DoDeposit command)
        {
            var accountAggregate = _eventRepository.GetById(command.AccountId);
            accountAggregate.Deposit(Amount.Create(command.Amount));
            await _eventRepository.Save(accountAggregate);

            return Result.Ok();
        }
    }
}
