using TodoAspireApp.Application.UseCases.Authentication;

namespace TodoAspireApp.Application.UseCases.LinkAccounts.Approval
{
    public class ApprovalUseCaseRequest(Guid requestLinkAccountId, Guid userId) : IUseCaseRequest
    {
        public Guid RequestLinkAccountId { get; internal set; } = requestLinkAccountId;
        public Guid UserId { get; internal set; } = userId;
    }
}
