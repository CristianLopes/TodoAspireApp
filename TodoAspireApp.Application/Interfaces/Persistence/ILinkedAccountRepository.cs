using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.Interfaces.Persistence
{
    public interface ILinkedAccountRepository
    {
        Task<LinkedAccount> Add(LinkedAccount linkedAccount);
        Task<LinkedAccount?> FindById(Guid userId);
    }
}
