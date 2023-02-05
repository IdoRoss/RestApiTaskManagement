using Microsoft.EntityFrameworkCore;
using RestApiTaskManagement.Models;
using System.Diagnostics;

namespace RestApiTaskManagement.Data
{
    public class TasksContext: DbContext
    {
        public TasksContext(DbContextOptions<TasksContext> options):base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTask> Tasks { get; set; }

    }
}
