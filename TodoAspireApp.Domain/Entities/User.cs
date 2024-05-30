using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoAspireApp.Domain.Entities
{
    public class User
    {
        public User(string name, string email, string passwordHash)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }

        [Key]
        public Guid Id { get; private set; }

        [Required, MaxLength(150)]
        public string Name { get; private set; }

        [Required, MaxLength(80)]
        public string Email { get; private set; }

        [JsonIgnore]
        [Required, MaxLength(50)]
        public string PasswordHash { get; private set; }
    }
}
