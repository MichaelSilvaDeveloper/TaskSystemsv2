using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystemsV2.Models;
using TaskSystemsV2.Repositories.Interfaces;

namespace TaskSystemsV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            return await _taskRepository.GetTaskById(id);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> InsertTask([FromBody] TaskModel taskModel)
        {
            return await _taskRepository.InsertTask(taskModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel taskModel, int id)
        {
            return await _taskRepository.UpdateTask(taskModel, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
        }
    }
}