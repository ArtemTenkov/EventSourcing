using JustSaying.Models;
using System;

namespace SharedKernel.Domain.IntegrationEvents
{
    public class UserUnregistered : Message, IIntegrationEvent
    {
        public Guid UserId { get; }
        public UserUnregistered(Guid userId)
        {
            UserId = userId;
        }
    }
}
