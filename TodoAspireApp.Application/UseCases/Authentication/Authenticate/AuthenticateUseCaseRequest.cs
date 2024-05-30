namespace TodoAspireApp.Application.UseCases.Authentication.Authenticate
{
    public class AuthenticateUseCaseRequest(string email, string password) : IUseCaseRequest
    {
        public string Email { get; } = email;
        public string Password { get; } = password;
    }
}
