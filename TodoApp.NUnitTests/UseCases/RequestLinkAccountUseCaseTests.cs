using TodoAspireApp.Application.UseCases.LinkAccounts.Errors;
using TodoAspireApp.Application.UseCases.LinkAccounts.Request;
using TodoAspireApp.Domain.Entities;

namespace TodoApp.NUnitTests.UseCases
{
    [TestFixture(Category = "Request Link Account Use Case",
        Description = "Use cases for user Request to link your account with another user")]
    public class RequestLinkAccountUseCaseTests
    {
        RequestLinkAccountUseCase _sut;
        InMemoryUserRepository _userRepository;
        InMemoryLinkAccountRepository _linkAccountRepository;

        [SetUp]
        public void Setup()
        {
            _linkAccountRepository = new InMemoryLinkAccountRepository();
            _userRepository = new InMemoryUserRepository();
            _sut = new RequestLinkAccountUseCase(new InMemoryRequestLinkAccountRepository(), _linkAccountRepository);
        }

        [Test(Description = "Should be able to request account linking with another user")]
        public async Task ShouldBeAbleRequestAccountLinking()
        {
            var user1 = await _userRepository.Add(new User("User 1", "user1@gmail.com", "1232456"));
            var user2 = await _userRepository.Add(new User("User 2", "user2@gmail.com", "1232456"));

            var response = await _sut.Execute(new RequestLinkAccountUseCaseRequest(userId: user1.Id, linkedUserId: user2.Id));

            Assert.That(response.RequestLinkAccount, Is.Not.Null);
        }

        [Test(Description = "Should not be able to request account linking with another user who already have a linked account")]
        public async Task ShouldNotBeAbleRequestAccountLinkingWithUserLinkedToAnotherAccount()
        {
            var user1 = await _userRepository.Add(new User("User 1", "user1@gmail.com", "1232456"));
            var user2 = await _userRepository.Add(new User("User 2", "user2@gmail.com", "1232456"));
            var user3 = await _userRepository.Add(new User("User 3", "user2@gmail.com", "1232456"));

            // TODO: Review when implement approval request
            await _linkAccountRepository.Add(new LinkedAccount(user1.Id, user2.Id));

            Assert.ThrowsAsync<UserAlreadyHasLinkedAccountException>(async () => await _sut.Execute(new RequestLinkAccountUseCaseRequest(userId: user3.Id, linkedUserId: user2.Id)));
            Assert.ThrowsAsync<UserAlreadyHasLinkedAccountException>(async () => await _sut.Execute(new RequestLinkAccountUseCaseRequest(userId: user3.Id, linkedUserId: user1.Id)));
        }
    }
}
