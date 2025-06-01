using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    public interface IRepository
    {
        Task<List<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(int id);
    }
}