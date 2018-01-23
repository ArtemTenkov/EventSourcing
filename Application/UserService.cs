using Application.Commands;
using Application.Commands.Responses;
using Application.Queries;
using MediatR;
using SharedKernel.DataObjects;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;
using System.Threading.Tasks;

namespace Application
{
    public interface IUserService
    {        
        Task<RegisterUserResponse> RegisterUser(string userName, string lastName, PositionType position);
        Task<bool> UpdateUserName(string newUserName, string lastName);
    }

    public class UserService : IUserService
    {
        IMediator _mediator;
        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> UpdateUserName(string newUserName, string lastName)
        {
            var user = await _mediator.Send(new UserByNameQuery(lastName));
            var updatedSuccesfully = 
                await _mediator.Send(new UpdateUserName(user.Id, Name.Create(newUserName)));

            return updatedSuccesfully;
        }

        public async Task<RegisterUserResponse> RegisterUser(string userName, string lastName, PositionType position)
        {
            var registrationResult = await _mediator.Send(new RegisterUser(userName, lastName, position));
            return registrationResult;
        }
    }
}
