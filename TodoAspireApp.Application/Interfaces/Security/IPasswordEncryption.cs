namespace TodoAspireApp.Application.Interfaces.Security
{
    public interface IPasswordEncryption
    {
        string HashPassword(string password);
        bool Compare(string password, string passwordHash);
    }
}
