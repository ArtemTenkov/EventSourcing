using System;
using System.Threading.Tasks;
using Domain.Balance;
using MediatR;
using SharedKernel;
using System.Linq;

namespace Balance.Application.Queries.Handlers
{
    public class FindAccountIdByUserIdHandler : AsyncRequestHandler<FindAccountIdByUserId, Guid>
    {
        IEventRepository<AccountRoot> _eventRepository;
        public FindAccountIdByUserIdHandler(IEventRepository<AccountRoot> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        protected override async Task<Guid> HandleCore(FindAccountIdByUserId request)
        {
            var aggregate = _eventRepository.GetAggregates().SingleOrDefault(aggr => aggr.GetUserGuid == request.UserId);
            if (aggregate == null) return Guid.Empty;

            return aggregate.Id;
        }
    }
}
