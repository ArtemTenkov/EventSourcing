using System;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;

namespace Domain.User
{
    public interface IUserFactory
    {
        UserRoot CreateNew(string userName, string lastName,
            PositionType position);
        UserRoot Restore(Guid id, Name userName, Name lastName, PositionType position);
    }
    public class UserFactory : IUserFactory
    {
        public UserRoot CreateNew(string userName, string lastName,
            PositionType position)
        {
            var userAggregate = new UserRoot();
            userAggregate.Initialize(userName,
                lastName, position);
            return userAggregate;
        }

        public UserRoot Restore(Guid id, Name userName, Name lastName, PositionType position)
        {
            var aggregate = new UserRoot(id);
            //Do mapping here
            return aggregate;
        }
    }
}
