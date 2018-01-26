using System;

namespace SharedKernel.Domain.IntegrationEvents
{
    public class UserRegistered : IIntegrationEvent
    {
        public Guid UserId;
        public UserRegistered(Guid userId)
        {
            UserId = userId;
        }
    }
}
