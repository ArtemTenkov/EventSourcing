using MediatR;
using SharedKernel;
using SharedKernel.DataObjects;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class UserByNameQueryHandler : AsyncRequestHandler<UserByNameQuery, UserDto>
    {
        IUserRepository _rdbmsRepository;
        public UserByNameQueryHandler(IUserRepository rdbmsRepository)
        {
            _rdbmsRepository = rdbmsRepository;
        }
        protected override async Task<UserDto> HandleCore(UserByNameQuery request)
        {
            return await _rdbmsRepository.GetUser(request.Name);
        }
    }
}
