using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<User?> FindByEmail(string email);
    }
}
