using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.UseCases.Authentication.Register
{
    public class RegisterUseCaseResponse(User user) : IUseCaseResponse
    {
        public User User { get; } = user;
    }

}
