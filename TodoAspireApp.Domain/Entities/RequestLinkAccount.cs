using System.ComponentModel.DataAnnotations;

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

        public DateTime? Approved_At { get; set; }
       
        public bool Expired { get; set; }


        public User? User { get; set; }
        public User? LinkedUser { get; set; }

    }
}
