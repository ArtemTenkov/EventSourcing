using JustSaying.Models;
using System;

namespace SharedKernel.Domain.IntegrationEvents
{
    public class UserRegistered : Message, IIntegrationEvent
    {
        public Guid UserId;
        public UserRegistered(Guid userId)
        {
            UserId = userId;
        }
    }
}
