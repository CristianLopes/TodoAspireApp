using Microsoft.EntityFrameworkCore;
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

        public async Task<RequestLinkAccount?> GetById(Guid requestLinkAccountId)
        {
            return await context.RequestLinkAccounts.FirstOrDefaultAsync(x => x.Id == requestLinkAccountId);
        }

        public async Task<RequestLinkAccount> Update(RequestLinkAccount requestLinkAccount)
        {
            context.Entry(requestLinkAccount).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return requestLinkAccount;
        }
    }
}
