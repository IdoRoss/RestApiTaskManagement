namespace RestApiTaskManagement.Models
{
    public class UserTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public int Priority { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
