using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Application.UseCases.LinkAccounts.Approval;
using TodoAspireApp.Application.UseCases.LinkAccounts.Errors;
using TodoAspireApp.Domain.Entities;

namespace TodoApp.NUnitTests.UseCases
{
    [TestFixture(Category = "Approval Use Case Tests")]
    public class ApprovalUseCaseTests
    {
        private ApprovalUseCase _sut;
        private IRequestLinkAccountRepository _requestLinkAccountRepository;
        private ILinkedAccountRepository _linkedAccountRepository;


        [SetUp]
        public void Setup()
        {
            _requestLinkAccountRepository = new InMemoryRequestLinkAccountRepository();
            _linkedAccountRepository = new InMemoryLinkAccountRepository();
            _sut = new ApprovalUseCase(_requestLinkAccountRepository, _linkedAccountRepository);
        }

        [Test]
        public async Task ShouldBeAbleCreateALinkedAccount()
        {
            var userId = Guid.NewGuid();
            var linkedUserId = Guid.NewGuid();

            var request = await _requestLinkAccountRepository.Add(new RequestLinkAccount(userId, linkedUserId));
            var useCaseResponse = await _sut.Execute(new ApprovalUseCaseRequest(requestLinkAccountId: request.Id, request.LinkedUserId));
        
            Assert.That(useCaseResponse, Is.Not.Null);
            Assert.That(useCaseResponse.LinkedAccount, Is.Not.Null);
        }

        [Test]
        public void ShouldThrowKeyNotFoundWhenRequestIdIsInvalid()
        {
            Assert.ThrowsAsync<KeyNotFoundException>(
                    async () => await _sut.Execute(new ApprovalUseCaseRequest(requestLinkAccountId: Guid.NewGuid(), Guid.NewGuid())));
        }

        [Test]
        public async Task ShouldThrowUnauthorizedAccessExceptionWhenUserIsNotInRelationship()
        {
            var userId = Guid.NewGuid();
            var linkedUserId = Guid.NewGuid();

            var request = await _requestLinkAccountRepository.Add(new RequestLinkAccount(userId, linkedUserId));
            Assert.ThrowsAsync<UnauthorizedAccessException>(
                async () => await _sut.Execute(new ApprovalUseCaseRequest(requestLinkAccountId: request.Id, userId)));
        }

        [Test]
        public async Task ShouldThrowExpiredActionExceptionWhenRequestApprovalIsExpired()
        {
            var userId = Guid.NewGuid();
            var linkedUserId = Guid.NewGuid();

            var request = await _requestLinkAccountRepository.Add(new RequestLinkAccount(userId, linkedUserId));
            
            //Should have a rule to expire, but we don´t have it now.
            request.Expired = true;
            await _requestLinkAccountRepository.Update(request);

            Assert.ThrowsAsync<ExpiredActionException>(
                async () => await _sut.Execute(new ApprovalUseCaseRequest(requestLinkAccountId: request.Id, linkedUserId)));
        }

        [Test]
        public async Task ShouldThrowAlreadyApprovedExceptionWhenRequestApprovalIsAlreadyApproved()
        {
            var userId = Guid.NewGuid();
            var linkedUserId = Guid.NewGuid();

            var request = await _requestLinkAccountRepository.Add(new RequestLinkAccount(userId, linkedUserId));
            var useCaseResponse = await _sut.Execute(new ApprovalUseCaseRequest(requestLinkAccountId: request.Id, request.LinkedUserId));

            Assert.ThrowsAsync<AlreadyApprovedException>(
                 async () => await _sut.Execute(new ApprovalUseCaseRequest(requestLinkAccountId: request.Id, linkedUserId)));
        }
    }
}
