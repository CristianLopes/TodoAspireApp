using System.ComponentModel.DataAnnotations;

namespace TodoAspireApp.Domain.Entities
{
    public class UserTodos
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TodoItemId { get; set; }

        public User User { get; set; } = null;
        public TodoItem TodoItem { get; set; } = null;
    }
}
