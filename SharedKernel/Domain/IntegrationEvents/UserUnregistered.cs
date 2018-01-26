using System;

namespace SharedKernel.Domain.IntegrationEvents
{
    public class UserUnregistered : IIntegrationEvent
    {
        public Guid UserId { get; }
        public UserUnregistered(Guid userId)
        {
            UserId = userId;
        }
    }
}
