using MediatR;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;

namespace Balance.Application.Queries
{
    public class GetAllAccounts : IRequest<Dictionary<Guid, Amount>>
    {
    }
}
