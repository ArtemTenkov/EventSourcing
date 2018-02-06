using MediatR;
using System;

namespace Balance.Application.Queries
{
    public class FindAccountIdByUserId : IRequest<Guid>
    {
        public Guid UserId { get; }
        public FindAccountIdByUserId(Guid userId)
        {
            UserId = userId;
        }
    }
}
