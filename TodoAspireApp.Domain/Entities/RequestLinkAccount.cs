using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAspireApp.Domain.Entities
{
    public class RequestLinkAccount(Guid userId, Guid linkedUserId)
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; } = userId;

        [Required]
        public Guid LinkedUserId { get; private set; } = linkedUserId;

        public DateTime? Approved_At { get; private set; }
       
        public bool Expired { get; private set; }


        public User? User { get; set; }
        public User? LinkedUser { get; set; }

    }
}
