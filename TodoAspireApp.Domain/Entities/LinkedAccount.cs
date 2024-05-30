using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAspireApp.Domain.Entities
{
    public class LinkedAccount(Guid userId, Guid linkedUserId)
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; } = userId;

        public User? User { get; set; }

        [Required]
        public Guid LinkedUserId { get; private set; } = linkedUserId;

        public User? LinkedUser { get; set; }
    }
}
