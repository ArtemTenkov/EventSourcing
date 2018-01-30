using SharedKernel.DataObjects;
using System;
using System.Threading.Tasks;

namespace SharedKernel
{
    public interface IUserRepository
    {
        Task AddUser(Guid id, string firstName, string lastName);
        Task<UserDto> GetUser(string lastName);
        Task UpdateUser(Guid id, string newName);
    }
}
