using MediatR;
using SharedKernel.DataObjects;
using System.Collections.Generic;

namespace User.Application.Queries
{
    public class GetAllUsers : IRequest<IEnumerable<UserDto>>
    {
    }
}
