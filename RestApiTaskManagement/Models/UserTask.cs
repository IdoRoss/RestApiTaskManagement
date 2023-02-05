using System.Text.Json.Serialization;

namespace RestApiTaskManagement.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleated { get; set; } = false;
        public int Priority { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
