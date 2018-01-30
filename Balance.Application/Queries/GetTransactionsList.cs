using MediatR;
using SharedKernel.DataObjects;
using System;
using System.Collections.Generic;

namespace Balance.Application.Queries
{
    public class GetTransactionsList : IRequest<List<TransactionDto>>
    {
        public Guid UserId { get; }
        public GetTransactionsList(Guid userId)
        {
            UserId = userId;
        }
    }
}
