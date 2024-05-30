using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Application.Interfaces.Security;
using TodoAspireApp.Application.UseCases.Authentication.Errors;
using TodoAspireApp.Domain.Entities;

namespace TodoAspireApp.Application.UseCases.Authentication.Register
{
    public class RegisterUseCase(IUserRepository userRepository, IPasswordEncryption passwordEncryption) 
        : IUseCase<RegisterUseCaseRequest, RegisterUseCaseResponse>
    {
        public async Task<RegisterUseCaseResponse> Execute(RegisterUseCaseRequest request)
        {
            var userWithSameEmail = await userRepository.FindByEmail(request.Email);
            if (userWithSameEmail is not null)
            {
                throw new UserAlreadyExistsException();
            }

            var passwordHash = passwordEncryption.HashPassword(request.Password);
            var user = await userRepository.Create(new User(request.Name, request.Email, passwordHash));
            return new(user);
        }
    }
}
