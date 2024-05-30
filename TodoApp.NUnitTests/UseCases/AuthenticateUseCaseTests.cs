using TodoAspireApp.Application.UseCases.Authentication.Authenticate;
using TodoAspireApp.Domain.Entities;
using TodoAspireApp.Infrastructure.Security;

namespace TodoApp.NUnitTests.UseCases
{
    [TestFixture(Author = "Cristian", Category = "Authenticate Use Case", Description = "All use cases for registration")]
    public class AuthenticateUseCaseTests
    {
        [Test(Description = "Should be able to authenticate")]
        public async Task ShouldBeAbleToAuthenticate()
        {
            AuthenticateUseCaseResponse? userAuthenticated = null;

            var repository = new InMemoryUserRepository();
            var encryption = new PasswordEncryption();

            var useCase = new AuthenticateUseCase(repository, encryption);

            await repository.Create(new User(name: "Cristian", email: "cristian@gmail.com", passwordHash: encryption.HashPassword("123456")));

            userAuthenticated = await useCase.Execute(new AuthenticateUseCaseRequest(email: "cristian@gmail.com", password: "123456"));

            Assert.IsNotNull(userAuthenticated);
        }
    }

}
