using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.Interfaces.Persistence
{
    public interface ILinkedAccountRepository
    {
        Task<LinkedAccount?> FindById(Guid userId);
    }
}
