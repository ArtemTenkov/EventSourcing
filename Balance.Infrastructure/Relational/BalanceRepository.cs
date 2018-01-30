using System;
using System.Collections.Generic;
using Balance.Infrastructure.Models;
using SharedKernel;
using SharedKernel.DataObjects;
using System.Linq;
using SharedKernel.FlowControl;
using System.Threading.Tasks;
using SharedKernel.Enums;

namespace Balance.Infrastructure.Relational
{
    public class BalanceRepository : IBalanceRepository
    {
        private QueryContext _dbContext;
        public BalanceRepository(QueryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Add(TransactionDto transactionDto)
        {
            try
            {
                _dbContext.Transaction.Add(new Transaction
                {
                    Id = transactionDto.Id,
                    Amount = transactionDto.Amount,
                    TransactionDateTime = transactionDto.TransactionDateTime,
                    TransactionStatusCode = transactionDto.TransactionStatusCode,
                    UserId = transactionDto.UserId
                });
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                return Result.Fail(ErrorType.DatabaseError, exc.Message);
            }            

            return Result.Ok();
        }

        public List<TransactionDto> GetTransactions(Guid userId)
        {
            var transactionList = _dbContext.Transaction.Where(t => t.UserId == userId)
                .Select(txn => new TransactionDto(txn.Id, txn.UserId, txn.Amount, txn.TransactionDateTime, txn.TransactionStatusCode));

            return transactionList.ToList();
        }
    }
}
