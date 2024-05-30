using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Application.UseCases.Authentication;
using TodoAspireApp.Application.UseCases.LinkAccounts.Errors;
using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.UseCases.LinkAccounts.Request
{
    public class RequestLinkAccountUseCase(IRequestLinkAccountRepository requestLinkRepository, ILinkedAccountRepository linkedAccountRepository) 
        : IUseCase<RequestLinkAccountUseCaseRequest, RequestLinkAccountUseCaseResponse>
    {
        public async Task<RequestLinkAccountUseCaseResponse> Execute(RequestLinkAccountUseCaseRequest request)
        {
            var accounts = await Task.WhenAll(
                linkedAccountRepository.FindById(request.UserId), 
                linkedAccountRepository.FindById(request.LinkedUserId));

            var userAlreadyHasLinkedAccount = accounts.Any(x => x is not null);
            if (userAlreadyHasLinkedAccount)
            {
                throw new UserAlreadyHasLinkedAccountException();
            }

            var linkedAccount = await requestLinkRepository.Add(new RequestLinkAccount(request.UserId, request.LinkedUserId));
            return new(linkedAccount);
        }
    }
}
