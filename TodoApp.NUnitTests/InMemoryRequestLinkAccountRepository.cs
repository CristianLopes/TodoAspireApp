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

        public Task<RequestLinkAccount> GetById(Guid requestLinkAccountId)
        {
            return Task.FromResult(data.FirstOrDefault(x => x.Id == requestLinkAccountId));
        }

        public Task<RequestLinkAccount> Update(RequestLinkAccount requestLinkAccount)
        {
            var item = data.Where(x => x.Id == requestLinkAccount.Id).FirstOrDefault();
            item.Approved_At = requestLinkAccount.Approved_At;
            return Task.FromResult(item);
        }
    }
}
