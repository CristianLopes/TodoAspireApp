using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Infrastructure.Persistence
{
    public class RequestLinkAccountRepository(ApplicationDbContext context) 
        : IRequestLinkAccountRepository
    {
        public async Task<RequestLinkAccount> Add(RequestLinkAccount requestLinkAccount)
        {
            var entityEntry = await context.AddAsync(requestLinkAccount);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
