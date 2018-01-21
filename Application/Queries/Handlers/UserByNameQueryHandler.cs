using MediatR;
using SharedKernel;
using SharedKernel.DataObjects;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class UserByNameQueryHandler : AsyncRequestHandler<UserByNameQuery, UserDto>
    {
        IRdbmsRepository _rdbmsRepository;
        public UserByNameQueryHandler(IRdbmsRepository rdbmsRepository)
        {
            _rdbmsRepository = rdbmsRepository;
        }
        protected override async Task<UserDto> HandleCore(UserByNameQuery request)
        {
            return await _rdbmsRepository.GetUser(request.Name);
        }
    }
}
