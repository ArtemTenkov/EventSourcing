using System;
using System.Collections.Generic;
using SharedKernel.Domain;
using SharedKernel.Enums;

namespace Domain.User
{
    public class UserFactory : IAggregateFactory<UserRoot>
    {
        public AggregateRoot CreateNew(string userName, string lastName,
            PositionType position)
        {
            var userAggregate = new UserRoot();
            userAggregate.Initialize(userName,
                lastName, position);
            return userAggregate;
        }

        public UserRoot Restore(Guid id, IEnumerable<object> events = null)
        {
            var aggregate = new UserRoot(id, new UserState(events));
            return aggregate;
        }
    }
}
