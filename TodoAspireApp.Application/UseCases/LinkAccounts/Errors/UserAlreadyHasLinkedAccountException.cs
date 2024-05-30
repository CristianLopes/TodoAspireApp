namespace TodoAspireApp.Application.UseCases.LinkAccounts.Errors
{
    public class UserAlreadyHasLinkedAccountException : Exception
    {
        public UserAlreadyHasLinkedAccountException()
            : base("User Already Has Linked Account")
        {
        }
    }
}
