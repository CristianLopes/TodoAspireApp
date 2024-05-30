using Microsoft.EntityFrameworkCore;
using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Infrastructure.Persistence
{
    public class UserRepository(ApplicationDbContext context) 
        : IUserRepository
    {
        public async Task<User> Add(User user)
        {
            var entityEntry = await context.AddAsync(user);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public Task<User?> FindByEmail(string email)
        {
            return context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
