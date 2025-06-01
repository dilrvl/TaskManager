using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    public class TaskService : IService
    {
        private readonly IRepository _repository;

        public TaskService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddTaskAsync(string title)
        {
            var task = new TaskItem { Title = title};
            await _repository.AddAsync(task);
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            await _repository.UpdateAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
