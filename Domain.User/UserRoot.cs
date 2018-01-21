using Domain.User.Events;
using SharedKernel.Domain;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;
using System;

namespace Domain.User
{
    public class UserRoot : AggregateRoot
    {
        public Name Name { get { return _state.UserName; } }
        private readonly UserState _state;
        public UserRoot(Guid? id = null, UserState state = null)
        {
            Id = id.HasValue? id.Value: Guid.NewGuid();
            _state = state ?? new UserState();
        }

        internal void Initialize(string userName, string lastName, PositionType position)
        {
            AddDomainEvent(new UserCreated(userName, lastName, this.Id, position));
        }

        public void UpdateUserName(Name name)
        {
            AddDomainEvent(new UserNameUpdated(name.Value, this.Id));
        }
    }
}
