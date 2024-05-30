
namespace TodoAspireApp.Application.UseCases.Authentication.Register
{
    public class RegisterUseCaseRequest(string name, string email, string password) : IUseCaseRequest
    {
        public string Name { get; internal set; } = name;
        public string Email { get; internal set; } = email;
        public string Password { get; internal set; } = password;
    }
}
