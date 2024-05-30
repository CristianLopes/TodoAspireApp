using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Domain.Entities;

namespace TodoApp.NUnitTests
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public Task<User> Add(User user)
        {
            users.Add(user);
            return Task.FromResult(user);
        }

        public Task<User?> FindByEmail(string email)
        {
            return Task.FromResult(users.FirstOrDefault(x => x.Email == email));
        }
    }

}
