using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User?> FindByEmail(string email);
    }
}
