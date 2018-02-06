using Amazon;
using Amazon.Runtime;
using Balance.Application.Commands;
using Balance.Application.Queries;
using JustSaying;
using JustSaying.AwsTools;
using MediatR;
using SharedKernel.Domain.IntegrationEvents;
using SharedKernel.FlowControl;
using SharedKernel.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Balance.Application
{
    public interface IAccountService
    {
        Task<Guid> GetAccountIdByUserId(Guid userId);
        Task<Result> Deposit(Guid accountId, decimal amount);
        Task<Result> Withdraw(Guid accountId, decimal amount);
    }
    public class AccountService : IAccountService
    {
        IMediator _mediator;
        IHaveFulfilledPublishRequirements _publisher;
        public AccountService(IMediator mediator)
        {
            _mediator = mediator;
            CreateMeABus.DefaultClientFactory = () =>
            new DefaultAwsClientFactory(
                new BasicAWSCredentials(
                    "",
                    ""));

            _publisher = CreateMeABus.WithLogging(new Microsoft.Extensions.Logging.LoggerFactory())
                .InRegion(RegionEndpoint.SAEast1.SystemName)
                .WithSnsMessagePublisher<BalanceIncreased>()
                .WithSnsMessagePublisher<BalanceDecreased>();
        }

        public async Task<Result> Deposit(Guid accountId, decimal amount)
        {
            var depositResult = await _mediator.Send(new DoDeposit(accountId, Amount.Create(amount).Value));
            if (depositResult.IsSuccess)
               await _publisher.PublishAsync(new BalanceIncreased(transactionId: depositResult.Value.Id, userId: depositResult.Value.UserId, amount: amount));

            return depositResult;
        }

        public async Task<Result> Withdraw(Guid accountId, decimal amount)
        {
            var withdrawResult = await _mediator.Send(new DoWithdraw(accountId, amount));
            if (withdrawResult.IsSuccess)
               await _publisher.PublishAsync(new BalanceDecreased(transactionId: withdrawResult.Value.Id, userId: withdrawResult.Value.UserId, amount: amount));

            return withdrawResult;
        }       

        public async Task<Guid> GetAccountIdByUserId(Guid userId)
        {
            return await _mediator.Send(new FindAccountIdByUserId(userId));
        }
    }
}
