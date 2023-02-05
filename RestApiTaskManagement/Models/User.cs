

using System.Text.Json.Serialization;

namespace RestApiTaskManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<UserTask>? Tasks { get; set; }
    }
}
