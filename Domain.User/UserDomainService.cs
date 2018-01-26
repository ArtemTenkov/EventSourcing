using SharedKernel.FlowControl;
using System;

namespace Domain.User
{
    public interface IUserDomainService
    {
        Result DeleteUser(UserRoot user);
    }

    public class UserDomainService : IUserDomainService
    {
        public UserDomainService()
        {

        }
        public Result DeleteUser(UserRoot user)
        {
            throw new NotImplementedException();
        }
    }
}
