using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Data;
using TaskManager.Core;

namespace TaskManager
{
    internal static class Program
    {
        private static IServiceProvider serviceProvider;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);

            // Настройка DI контейнера
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            // Применение миграций
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            Application.Run(serviceProvider.GetRequiredService<TaskManager>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IService, TaskService>();
            services.AddSingleton<TaskManager>();
        }
    }
}