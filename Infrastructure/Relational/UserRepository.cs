using Infrastructure.Models;
using SharedKernel;
using System;
using System.Threading.Tasks;
using System.Linq;
using SharedKernel.DataObjects;
using SharedKernel.ValueObjects;

namespace Infrastructure.Relational
{
    public class UserRepository : IUserRepository
    {
        protected QueryContext _dbContext;
        public UserRepository(QueryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUser(Guid id, string firstName, string lastName)
        {
            _dbContext.User.Add(new User
            {
                Id = id,
                Name = firstName,
                LastName = lastName
            });

            _dbContext.SaveChanges();
        }

        public async Task<UserDto> GetUser(string lastName)
        {
            var user = _dbContext.User.FirstOrDefault(usr => usr.LastName == lastName);
            return new UserDto(user.Id, Name.Create(user.Name), Name.Create(user.LastName));
        }

        public async Task UpdateUser(Guid id, string newName)
        {
            var user = _dbContext.User.Find(id);
            if (user == null)
                throw new Exception("User not found");

            user.Name = newName;
            _dbContext.SaveChanges();
        }
    }
}
