using TodoAspireApp.Application.UseCases.Authentication;
using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.UseCases.LinkAccounts.Request
{
    public class RequestLinkAccountUseCaseResponse(RequestLinkAccount requestLinkAccount) 
        : IUseCaseResponse
    {
        public RequestLinkAccount RequestLinkAccount { get; set; } = requestLinkAccount;
    }
}