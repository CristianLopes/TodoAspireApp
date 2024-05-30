using TodoAspireApp.Application.UseCases.Authentication.Errors;
using TodoAspireApp.Application.UseCases.Authentication.Register;
using TodoAspireApp.Infrastructure.Security;

namespace TodoApp.NUnitTests.UseCases
{
    [TestFixture(Category = "Register Use Case", Description = "Use cases for user registration")]
    public class RegisterUseCaseTests
    {
        private RegisterUseCase _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new RegisterUseCase(new InMemoryUserRepository(), new PasswordEncryption());
        }

        [TestCase(Description = "Should be able to register")]
        public async Task ShouldBeAbleToRegister()
        {
            var registerUserResponse = await _sut.Execute(new RegisterUseCaseRequest(name: "Fulano", email: "fulano@gmail.com", password: "senha+secreta"));
            Assert.IsNotNull(registerUserResponse);
            Assert.IsNotNull(registerUserResponse.User);
        }

        [Test(Description = "Should hash user password upon registration")]
        public async Task ShouldHashUserPasswordUponRegistration()
        {
            var password = "senha+secreta";
            var registerUserResponse = await _sut.Execute(new RegisterUseCaseRequest(name: "Fulano", email: "fulano@gmail.com", password: password));

            PasswordEncryption passwordEncryption = new PasswordEncryption();
            var passwordAreEquals = passwordEncryption.Compare(password, registerUserResponse.User.PasswordHash);

            Assert.True(passwordAreEquals);
            Assert.That(registerUserResponse.User.PasswordHash, Is.Not.EqualTo(password));
        }

        [Test(Description = "Should not be able to register with same email twice")]
        public async Task ShouldNotBeAbleToRegisterWithSameEmailTwice()
        {
            await _sut.Execute(new RegisterUseCaseRequest(name: "Fulano", email: "fulano@gmail.com", password: "senha+secreta"));

            Assert.ThrowsAsync<UserAlreadyExistsException>(async () => await _sut.Execute(new RegisterUseCaseRequest(name: "Fulano", email: "fulano@gmail.com", password: "senha+secreta")));
        }
    }

}
