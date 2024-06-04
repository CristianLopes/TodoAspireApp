namespace TodoAspireApp.Application.UseCases.LinkAccounts.Errors;
public class AlreadyApprovedException : Exception
{
    public AlreadyApprovedException()
        : base("Request already approved")
    {
    }
}
