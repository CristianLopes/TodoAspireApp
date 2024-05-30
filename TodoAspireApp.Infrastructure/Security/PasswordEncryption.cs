using System.Text;
using TodoAspireApp.Application.Interfaces.Security;

namespace TodoAspireApp.Infrastructure.Security
{
    public class PasswordEncryption : IPasswordEncryption
    {
        public bool Compare(string password, string passwordHash)
        {
            var hash = HashPassword(password);
            return string.Equals(hash, passwordHash);
        }

        public string HashPassword(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }
    }
}
