using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Domain.Entities;

namespace TodoApp.NUnitTests
{
    public class InMemoryRequestLinkAccountRepository : IRequestLinkAccountRepository
    {
        private List<RequestLinkAccount> data = new List<RequestLinkAccount>();

        public Task<RequestLinkAccount> Add(RequestLinkAccount requestLinkAccount)
        {
            data.Add(requestLinkAccount);
            return Task.FromResult(requestLinkAccount);
        }
    }
}
