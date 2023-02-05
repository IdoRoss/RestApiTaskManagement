using RestApiTaskManagement.Models;

namespace RestApiTaskManagement.Services
{
    public interface IUserTasksService
    {
        public Task<UserTask?> CreateTask(UserTask task);

        public Task<UserTask?> UpdateTask(int id,UserTask task);
        public Task<bool> DeleteTask(int id);
        public Task<UserTask?> GetTask(int id);

        public Task<List<UserTask>?> GetAllTasks(int userId, string sortBy);
    }
}
