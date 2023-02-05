using Microsoft.AspNetCore.Mvc;
using RestApiTaskManagement.Models;

namespace RestApiTaskManagement.Services
{
    public interface IUsersService
    {
        public Task<User> SignUp(User user);
        public Task<User?> GetUser(int id);
    }
}
