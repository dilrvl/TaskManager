using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.Data;
using TaskManager.Core;

namespace TaskManager
{
    public partial class TaskManager : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IService _taskService;
        private BindingSource _bindingSource = new BindingSource();
        public TaskManager(IService taskService)
        {
            _taskService = taskService;
            InitializeComponent();
            Logger.Info("Приложение запущено.");
        }
        private async Task LoadTasksAsync()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            Logger.Info("Задачи успешно загружены.");
            _bindingSource.DataSource = tasks;
            dataGridViewTasks.DataSource = _bindingSource;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTask.Text))
            {
                await _taskService.AddTaskAsync(txtTask.Text);
                Logger.Info($"Задача добавлена: {txtTask.Text}");
                txtTask.Clear();
                await LoadTasksAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                var selectedTask = (TaskItem)dataGridViewTasks.SelectedRows[0].DataBoundItem;
                var newTitle = Microsoft.VisualBasic.Interaction.InputBox("Введите новое название задачи:",
                    "Редактирование задачи", selectedTask.Title);

                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    selectedTask.Title = newTitle;
                    await _taskService.UpdateTaskAsync(selectedTask);
                    Logger.Info($"Задача обновлена: {selectedTask.Id}, Новое название: {newTitle}");
                    await LoadTasksAsync();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                var selectedTask = (TaskItem)dataGridViewTasks.SelectedRows[0].DataBoundItem;
                await _taskService.DeleteTaskAsync(selectedTask.Id);
                Logger.Info($"Задача удалена: {selectedTask.Id}");
                await LoadTasksAsync();
            }
        }

        private async void dataGridViewTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Клик по чекбоксу
            {
                var task = (TaskItem)dataGridViewTasks.Rows[e.RowIndex].DataBoundItem;
                await _taskService.ToggleTaskCompletionAsync(task.Id);
                await LoadTasksAsync();
            }
        }

        private async void TaskManager_Load(object sender, EventArgs e)
        {
            await LoadTasksAsync();
            dataGridViewTasks.AutoGenerateColumns = false;
            // Очищаем существующие столбцы
            dataGridViewTasks.Columns.Clear();

            // Добавляем только нужные столбцы
            dataGridViewTasks.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "IsCompleted",
                HeaderText = "Выполнено",
                DataPropertyName = "IsCompleted" // Связываем с свойством модели
            });

            dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Title",
                HeaderText = "Задача",
                DataPropertyName = "Title" // Связываем с свойством модели
            });

            await LoadTasksAsync();
        }
    }
}
