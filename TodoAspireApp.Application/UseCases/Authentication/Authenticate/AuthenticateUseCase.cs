using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Application.Interfaces.Security;
using TodoAspireApp.Application.UseCases.Authentication.Errors;

namespace TodoAspireApp.Application.UseCases.Authentication.Authenticate
{
    public class AuthenticateUseCase : IUseCase<AuthenticateUseCaseRequest, AuthenticateUseCaseResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordEncryption _passwordEncryption;

        public AuthenticateUseCase(IUserRepository userRepository, IPasswordEncryption passwordEncryption)
        {
            _userRepository = userRepository;
            _passwordEncryption = passwordEncryption;
        }

        public async Task<AuthenticateUseCaseResponse> Execute(AuthenticateUseCaseRequest authenticateUseCaseRequest)
        {
            var user = await _userRepository.FindByEmail(authenticateUseCaseRequest.Email);
            if (user is null)
            {
                throw new InvalidCredentialsException();
            }

            var doesPasswordAreEqual = _passwordEncryption.Compare(authenticateUseCaseRequest.Password, user.PasswordHash);
            if (!doesPasswordAreEqual)
            {
                throw new InvalidCredentialsException();
            }

            return new(user);
        }
    }

}
