using TodoAspireApp.Application.UseCases.Authentication;

namespace TodoAspireApp.Application.UseCases.LinkAccounts.Request
{
    public class RequestLinkAccountUseCaseRequest(Guid userId, Guid linkedUserId) 
        : IUseCaseRequest
    {
        public Guid UserId { get; } = userId;
        public Guid LinkedUserId { get; } = linkedUserId;
    }
}