using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Domain.Entities;

namespace TodoApp.NUnitTests
{
    public class InMemoryLinkAccountRepository : ILinkedAccountRepository
    {
        private List<LinkedAccount> data = new List<LinkedAccount>();
        public Task<LinkedAccount?> FindById(Guid userId)
        {
            return Task.FromResult(data.FirstOrDefault(x => x.UserId == userId || x.LinkedUserId == userId));
        }

        public Task<LinkedAccount> Add(LinkedAccount linkedAccount)
        {
            data.Add(linkedAccount);
            return Task.FromResult(linkedAccount);
        }
    }
}
