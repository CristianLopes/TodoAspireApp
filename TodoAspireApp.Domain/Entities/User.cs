using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoAspireApp.Domain.Entities
{
    public class User(string name, string email, string passwordHash)
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        [Required, MaxLength(150)]
        public string Name { get; private set; } = name;

        [Required, MaxLength(80)]
        public string Email { get; private set; } = email;

        [JsonIgnore]
        [Required, MaxLength(50)]
        public string PasswordHash { get; private set; } = passwordHash;
    }
}
