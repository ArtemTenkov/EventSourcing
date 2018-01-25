using MediatR;
using SharedKernel.DataObjects;

namespace Application.Queries
{
    public class FindUserByName : IRequest<UserDto>
    {
        public string Name { get; }
        public FindUserByName(string name)
        {
            Name = name;
        }
    }
}
