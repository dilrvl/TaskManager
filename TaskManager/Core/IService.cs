using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    public interface IService
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task AddTaskAsync(string title);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int id);
    }
}