using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Application.UseCases.Authentication;
using TodoAspireApp.Application.UseCases.LinkAccounts.Errors;
using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.UseCases.LinkAccounts.Approval
{
    public class ApprovalUseCase(IRequestLinkAccountRepository requestLinkAccountRepository, ILinkedAccountRepository linkedAccountRepository) 
        : IUseCase<ApprovalUseCaseRequest, ApprovalUseCaseResponse>
    {
        public async Task<ApprovalUseCaseResponse> Execute(ApprovalUseCaseRequest request)
        {
            var requestLinkAccount =  await requestLinkAccountRepository.GetById(requestLinkAccountId: request.RequestLinkAccountId);
            if (requestLinkAccount is null)
            {
                throw new KeyNotFoundException();
            }

            if (requestLinkAccount.LinkedUserId != request.UserId)
            {
                throw new UnauthorizedAccessException();
            }

            if (requestLinkAccount.Expired)
            {
                throw new ExpiredActionException();
            }

            if (requestLinkAccount.Approved_At.HasValue)
            {
                throw new AlreadyApprovedException();
            }

            //update requestLinkAccount with approved date
            requestLinkAccount.Approved_At = DateTime.UtcNow;
            await requestLinkAccountRepository.Update(requestLinkAccount);
            var linkedAccount =  await linkedAccountRepository.Add(new LinkedAccount(requestLinkAccount.UserId, requestLinkAccount.LinkedUserId));

            return new(linkedAccount);
        }
    }
}
