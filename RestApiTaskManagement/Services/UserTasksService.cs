using Microsoft.EntityFrameworkCore;
using RestApiTaskManagement.Data;
using RestApiTaskManagement.Models;

namespace RestApiTaskManagement.Services
{
    public class UserTasksService : IUserTasksService
    {
        private readonly TasksContext _context;

        public UserTasksService(TasksContext context)
        {
            _context = context;
        }

        public async Task<UserTask?> CreateTask(UserTask task)
        {
            if(!_context.Users.Any(u=>u.Id == task.UserId)) { return null; }
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var userTask = await _context.Tasks.FindAsync(id);
            if (userTask == null)
            {
                return false;
            }

            _context.Tasks.Remove(userTask);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<UserTask>?> GetAllTasks(int userId,string sortBy)
        {
            if(sortBy == "priority")
            {
                var tasks = await _context.Tasks.Where(t => t.UserId == userId).OrderBy(t => t.Priority).ToListAsync();
                return tasks;
            }
            else if (sortBy == "status")
            {
                var tasks = await _context.Tasks.Where(t => t.UserId == userId).OrderBy(t => t.IsCompleated).ToListAsync();
                return tasks;
            }
            else
            {
                var tasks = await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
                return tasks;
            }

        }

        public async Task<UserTask?> GetTask(int id)
        {
            var userTask = await _context.Tasks.Where(t=>t.Id == id).Include(t=>t.User).FirstOrDefaultAsync();

            return userTask;
        }

        public async Task<UserTask?> UpdateTask(int id,UserTask task)
        {
            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTaskExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return task;
        }

        private bool UserTaskExists(int id)
        {
            return _context.Tasks.Any(t => t.Id == id);
        }
    }
}
