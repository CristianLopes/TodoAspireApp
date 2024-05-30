using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.UseCases.Authentication.Authenticate
{
    public class AuthenticateUseCaseResponse(User user) : IUseCaseResponse
    {
        public User User { get; } = user;
    }
}
