using Application.Commands;
using Application.Commands.Responses;
using Application.Queries;
using MediatR;
using SharedKernel.Domain.IntegrationEvents;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;
using System.Threading.Tasks;

namespace Application
{
    public interface IUserService
    {        
        Task<RegisterUserResponse> RegisterUser(string userName, string lastName, PositionType position);
        Task<bool> UpdateUserName(string newUserName, string lastName);
        Task<string> PromoteUser(string lastName, PositionType newPosition);
        Task<string> UnregisterUser(string lastName);
    }

    //NB will use only message bus here
    public class UserService : IUserService
    {
        IMediator _mediator;
        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> UpdateUserName(string newUserName, string lastName)
        {
            var user = await _mediator.Send(new FindUserByName(lastName));
            var updatedSuccesfully = 
                await _mediator.Send(new UpdateUserName(user.LastName, Name.Create(newUserName)));

            return updatedSuccesfully;
        }

        public async Task<RegisterUserResponse> RegisterUser(string userName, string lastName, PositionType position)
        {
            var registrationResult = await _mediator.Send(new RegisterUser(userName, lastName, position));
            if (string.IsNullOrEmpty(registrationResult.ErrorMessage))
               await _mediator.Publish(new UserRegistered());

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
            var successfullyUnregistered = await _mediator.Send(new UnregisterUser());
            if (successfullyUnregistered)
                await _mediator.Publish(new UserUnregistered());

            return string.Empty;
        }
    }
}
