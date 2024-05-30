namespace TodoAspireApp.Application.UseCases.Authentication.Errors
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException()
            : base("Invalid Credentials")
        {
        }
    }
}
