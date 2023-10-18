using Microsoft.EntityFrameworkCore;
using TaskSystemsV2.Data;
using TaskSystemsV2.Models;
using TaskSystemsV2.Repositories.Interfaces;

namespace TaskSystemsV2.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContextV2 _dBContext;

        public TaskRepository(TaskSystemDBContextV2 dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dBContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            var searchTaskById = await _dBContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (searchTaskById == null)
                throw new Exception($"Task para o id: {id} não foi encontrado");
            return searchTaskById;
        }

        public async Task<TaskModel> InsertTask(TaskModel taskModel)
        {
            await _dBContext.Tasks.AddAsync(taskModel);
            await _dBContext.SaveChangesAsync();
            return taskModel;
        }

        public async Task<TaskModel> UpdateTask(TaskModel taskModel, int id)
        {
            var editTaskById = await GetTaskById(id);
            if(editTaskById == null)
                throw new Exception($"Task para o id: {id} não foi encontrado");

            editTaskById.Name = taskModel.Name;
            editTaskById.Description = taskModel.Description;
            editTaskById.Status = taskModel.Status;
            editTaskById.UserId = taskModel.UserId;

            _dBContext.Tasks.Update(editTaskById);
            await _dBContext.SaveChangesAsync();
            return editTaskById;
        }

        public async Task DeleteTask(int id)
        {
            var deleteTaskById = await GetTaskById(id);
            if (deleteTaskById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado");

            _dBContext.Tasks.Remove(deleteTaskById);
            await _dBContext.SaveChangesAsync();
        }
    }
}