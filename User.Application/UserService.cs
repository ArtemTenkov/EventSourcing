
using User.Application.Commands;
using User.Application.Queries;
using JustSaying;
using JustSaying.AwsTools;
using MediatR;
using SharedKernel.Domain.IntegrationEvents;
using SharedKernel.Enums;
using SharedKernel.FlowControl;
using SharedKernel.ValueObjects;
using System;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon;

namespace User.Application
{
    public interface IUserService
    {        
        Task<Result<Guid>> RegisterUser(string userName, string lastName, PositionType position);
        Task<bool> UpdateUserName(string newUserName, string lastName);
        Task<string> PromoteUser(string lastName, PositionType newPosition);
        Task<string> UnregisterUser(string lastName);
    }

    //NB will use only message bus here
    public class UserService : IUserService
    {
        IMediator _mediator;
        IHaveFulfilledPublishRequirements _publisher;
        public UserService(IMediator mediator)
        {
            _mediator = mediator;

            CreateMeABus.DefaultClientFactory = () =>
            new DefaultAwsClientFactory(
                new BasicAWSCredentials(
                    "",
                    ""));

            _publisher = CreateMeABus.WithLogging(new Microsoft.Extensions.Logging.LoggerFactory())
                .InRegion(RegionEndpoint.SAEast1.SystemName)
                .WithSnsMessagePublisher<UserRegistered>();
        }

        public async Task<bool> UpdateUserName(string newUserName, string lastName)
        {
            var user = await _mediator.Send(new FindUserByName(lastName));
            var updatedSuccesfully = 
                await _mediator.Send(new UpdateUserName(user.LastName, Name.Create(newUserName)));

            return updatedSuccesfully;
        }

        public async Task<Result<Guid>> RegisterUser(string userName, string lastName, PositionType position)
        {
            var registrationResult = await _mediator.Send(new RegisterUser(userName, lastName, position));
            if (registrationResult.IsSuccess)
                await _publisher.PublishAsync(new UserRegistered(registrationResult.Value));

            return registrationResult;
        }

        public async Task<string> PromoteUser(string lastName, PositionType newPosition)
        {
            var succesfullyPromoted = await _mediator.Send(new PromoteUser());
            if (succesfullyPromoted)
                await _mediator.Publish(new UserPromoted());

            return string.Empty;
        }

        public async Task<string> UnregisterUser(string lastName)
        {
            var unregisteredUserId = await _mediator.Send(new UnregisterUser(lastName));
            if (unregisteredUserId != null)
                await _mediator.Publish(new UserUnregistered(unregisteredUserId));

            return string.Empty;
        }
    }
}
