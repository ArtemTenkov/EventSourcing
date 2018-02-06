using Balance.Read.Application.Queries;
using MediatR;
using SharedKernel.DataObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Balance.Read.Application
{
    public interface IReadAccountService
    {
        Task<List<TransactionDto>> GetAllTransactions(Guid userId);        
    }
    public class ReadAccountService : IReadAccountService
    {
        IMediator _mediator;
        public ReadAccountService(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        public async Task<List<TransactionDto>> GetAllTransactions(Guid userId)
        {
            return await _mediator.Send(new GetTransactionsList(userId));
        }        
    }
}
