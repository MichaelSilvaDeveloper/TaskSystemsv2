using TaskSystemsV2.Models;

namespace TaskSystemsV2.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasks();

        Task<TaskModel> GetTaskById(int id);

        Task<TaskModel> InsertTask(TaskModel user);

        Task<TaskModel> UpdateTask(TaskModel user, int id);

        Task DeleteTask(int id);
    }
}