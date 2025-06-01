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
            Logger.Info("���������� ��������.");
        }
        private async Task LoadTasksAsync()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            Logger.Info("������ ������� ���������.");
            _bindingSource.DataSource = tasks;
            dataGridViewTasks.DataSource = _bindingSource;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTask.Text))
            {
                await _taskService.AddTaskAsync(txtTask.Text);
                Logger.Info($"������ ���������: {txtTask.Text}");
                txtTask.Clear();
                await LoadTasksAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                var selectedTask = (TaskItem)dataGridViewTasks.SelectedRows[0].DataBoundItem;
                var newTitle = Microsoft.VisualBasic.Interaction.InputBox("������� ����� �������� ������:",
                    "�������������� ������", selectedTask.Title);

                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    selectedTask.Title = newTitle;
                    await _taskService.UpdateTaskAsync(selectedTask);
                    Logger.Info($"������ ���������: {selectedTask.Id}, ����� ��������: {newTitle}");
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
                Logger.Info($"������ �������: {selectedTask.Id}");
                await LoadTasksAsync();
            }
        }

        private async void dataGridViewTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // ���� �� ��������
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
            // ������� ������������ �������
            dataGridViewTasks.Columns.Clear();

            // ��������� ������ ������ �������
            dataGridViewTasks.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "IsCompleted",
                HeaderText = "���������",
                DataPropertyName = "IsCompleted" // ��������� � ��������� ������
            });

            dataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Title",
                HeaderText = "������",
                DataPropertyName = "Title" // ��������� � ��������� ������
            });

            await LoadTasksAsync();
        }
    }
}
