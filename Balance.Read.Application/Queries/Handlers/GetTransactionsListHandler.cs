using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SharedKernel;
using SharedKernel.DataObjects;

namespace Balance.Read.Application.Queries.Handlers
{
    public class GetTransactionsListHandler : AsyncRequestHandler<GetTransactionsList, List<TransactionDto>>
    {
        IBalanceRepository _balanceRepository;
        public GetTransactionsListHandler(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        protected override async Task<List<TransactionDto>> HandleCore(GetTransactionsList request)
        {
            return _balanceRepository.GetTransactions(request.UserId);
        }
    }
}
