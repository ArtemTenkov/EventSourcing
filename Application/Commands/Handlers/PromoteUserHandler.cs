﻿using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Handlers
{
    public class PromoteUserHandler : AsyncRequestHandler<PromoteUser, bool>
    {
        protected override async Task<bool> HandleCore(PromoteUser command)
        {
            throw new System.NotImplementedException();
        }
    }
}