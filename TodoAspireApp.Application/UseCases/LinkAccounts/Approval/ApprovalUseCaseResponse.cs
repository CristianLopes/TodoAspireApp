using TodoAspireApp.Application.UseCases.Authentication;
using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.UseCases.LinkAccounts.Approval
{
    public class ApprovalUseCaseResponse : IUseCaseResponse
    {
        public ApprovalUseCaseResponse(LinkedAccount linkedAccount)
        {
            LinkedAccount = linkedAccount;
        }

        public LinkedAccount LinkedAccount { get; }
    }
}
