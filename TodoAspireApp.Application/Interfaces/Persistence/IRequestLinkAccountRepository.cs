using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.Interfaces.Persistence
{
    public interface IRequestLinkAccountRepository
    {
        Task<RequestLinkAccount> Add(RequestLinkAccount requestLinkAccount);
        Task<RequestLinkAccount> Update(RequestLinkAccount requestLinkAccount);
        Task<RequestLinkAccount?> GetById(Guid requestLinkAccountId);
    }
}
