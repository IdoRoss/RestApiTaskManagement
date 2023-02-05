using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiTaskManagement.Data;
using RestApiTaskManagement.Models;
using RestApiTaskManagement.Services;

namespace RestApiTaskManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private readonly IUserTasksService _userTasksService;


        public UserTasksController(IUserTasksService userTasksService)
        {
            _userTasksService = userTasksService;
        }


        // GET: api/UserTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTask>> GetTask(int id)
        {
            var task = await _userTasksService.GetTask(id);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST: api/UserTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserTask>> CreateTask(UserTaskDto userTaskDto)
        {

            var userTask = new UserTask
            {
                Title = userTaskDto.Title,
                Description= userTaskDto.Description,
                Priority = userTaskDto.Priority,
                UserId = userTaskDto.UserId
            };

            var newTask = await _userTasksService.CreateTask(userTask);
            if (newTask == null)
            {
                return BadRequest(userTask);
            }
            return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
        }


        // GET: api/UserTasks
        [HttpGet("{id}/{sortBy}")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetTasks(int id, string sortBy)
        {
            return Ok(await _userTasksService.GetAllTasks(id, sortBy));
        }


        // PUT: api/UserTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UserTaskDto userTaskDto)
        {
            var userTask = new UserTask
            {
                Id= id,
                Title = userTaskDto.Title,
                Description = userTaskDto.Description,
                Priority = userTaskDto.Priority,
                UserId = userTaskDto.UserId
            };

            var updated = await _userTasksService.UpdateTask(id, userTask);
            if(updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }


        // DELETE: api/UserTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTask(int id)
        {
            bool success = await _userTasksService.DeleteTask(id);
            if(success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        
    }
}
