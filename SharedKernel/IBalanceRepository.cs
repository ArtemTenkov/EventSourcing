using SharedKernel.DataObjects;
using SharedKernel.FlowControl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel
{
    public interface IBalanceRepository
    {
        List<TransactionDto> GetTransactions(Guid userId);
        Task<Result> Add(TransactionDto transactionDto);
    }
}
