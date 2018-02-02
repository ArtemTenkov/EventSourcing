using Balance.Infrastructure.EventSource;
using MediatR;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Balance.Application.Queries.Handlers
{
    public class GetAllAccountsHandler : AsyncRequestHandler<GetAllAccounts, Dictionary<Guid, Amount>>
    {
        EventRepository _balanceEventRepository;
        public GetAllAccountsHandler(EventRepository balanceRepository)
        {
            _balanceEventRepository = balanceRepository;
        }
        protected override async Task<Dictionary<Guid, Amount>> HandleCore(GetAllAccounts request)
        {
            var aggregates = _balanceEventRepository.GetAggregates();
            if (aggregates == null || !aggregates.Any()) return null;

            var aggregateAmounts = new Dictionary<Guid, Amount>();
            foreach (var aggregate in aggregates)
                aggregateAmounts.Add(aggregate.Id, aggregate.GetAmount);

            return aggregateAmounts;
        }
    }
}
