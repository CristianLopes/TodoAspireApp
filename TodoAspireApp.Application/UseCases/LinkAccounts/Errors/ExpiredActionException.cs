namespace TodoAspireApp.Application.UseCases.LinkAccounts.Errors
{
    [Serializable]
    public class ExpiredActionException : Exception
    {
        public ExpiredActionException()
             : base("Expired Action")
        {
        }
    }
}