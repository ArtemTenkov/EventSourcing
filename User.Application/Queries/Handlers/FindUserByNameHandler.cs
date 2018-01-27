using MediatR;
using SharedKernel;
using SharedKernel.DataObjects;
using System.Threading.Tasks;

namespace User.Application.Queries.Handlers
{
    public class FindUserByNameHandler : AsyncRequestHandler<FindUserByName, UserDto>
    {
        IUserRepository _rdbmsRepository;
        public FindUserByNameHandler(IUserRepository rdbmsRepository)
        {
            _rdbmsRepository = rdbmsRepository;
        }
        protected override async Task<UserDto> HandleCore(FindUserByName request)
        {
            return await _rdbmsRepository.GetUser(request.Name);
        }
    }
}
