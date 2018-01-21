using MediatR;
using SharedKernel.DataObjects;

namespace Application.Queries
{
    public class UserByNameQuery : IRequest<UserDto>
    {
        public string Name { get; }
        public UserByNameQuery(string name)
        {
            Name = name;
        }
    }
}
