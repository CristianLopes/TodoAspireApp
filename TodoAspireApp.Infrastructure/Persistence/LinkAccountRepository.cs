using Microsoft.EntityFrameworkCore;
using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Infrastructure.Persistence
{
    public class LinkAccountRepository(ApplicationDbContext context) : ILinkedAccountRepository
    {
        public Task<LinkedAccount?> FindById(Guid userId)
        {
            return context.LinkedAccounts.FirstOrDefaultAsync(x => x.UserId == userId || x.LinkedUserId == userId);
        }
    }
}
