namespace TodoAspireApp.Application.UseCases.Authentication.Errors
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() 
            : base("User Already Exists")
        {
        }
    }
}
