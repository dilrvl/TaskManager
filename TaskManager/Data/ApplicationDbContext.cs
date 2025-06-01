
using Microsoft.EntityFrameworkCore;
using TaskManager.Core;

namespace TaskManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
