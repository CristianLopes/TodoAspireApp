using System.ComponentModel.DataAnnotations;

namespace TodoAspireApp.Domain.Entities
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
