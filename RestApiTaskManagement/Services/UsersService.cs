using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiTaskManagement.Data;
using RestApiTaskManagement.Models;

namespace RestApiTaskManagement.Services
{
    public class UsersService : IUsersService
    {
        private readonly TasksContext _context;

        public UsersService(TasksContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(int id)
        {
            var user = await _context.Users.Where(u=> u.Id == id).Include(u=>u.Tasks).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> SignUp(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
