namespace TaskManager
{
    partial class TaskManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTask = new TextBox();
            btnAdd = new Button();
            dataGridViewTasks = new DataGridView();
            IsCompleted = new DataGridViewCheckBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).BeginInit();
            SuspendLayout();
            // 
            // txtTask
            // 
            txtTask.Location = new Point(12, 12);
            txtTask.Name = "txtTask";
            txtTask.Size = new Size(400, 27);
            txtTask.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(420, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridViewTasks
            // 
            dataGridViewTasks.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTasks.Columns.AddRange(new DataGridViewColumn[] { IsCompleted, Title });
            dataGridViewTasks.Location = new Point(12, 45);
            dataGridViewTasks.MultiSelect = false;
            dataGridViewTasks.Name = "dataGridViewTasks";
            dataGridViewTasks.RowHeadersWidth = 51;
            dataGridViewTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTasks.Size = new Size(560, 270);
            dataGridViewTasks.TabIndex = 2;
            dataGridViewTasks.CellContentClick += dataGridViewTasks_CellContentClick;
            // 
            // IsCompleted
            // 
            IsCompleted.HeaderText = "Выполнено";
            IsCompleted.MinimumWidth = 6;
            IsCompleted.Name = "IsCompleted";
            IsCompleted.Width = 125;
            // 
            // Title
            // 
            Title.HeaderText = "Задача";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.Width = 125;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(12, 320);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 29);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(470, 320);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // TaskManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(dataGridViewTasks);
            Controls.Add(btnAdd);
            Controls.Add(txtTask);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TaskManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление задачами";
            Load += TaskManager_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTask;
        private Button btnAdd;
        private DataGridView dataGridViewTasks;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridViewCheckBoxColumn IsCompleted;
        private DataGridViewTextBoxColumn Title;
    }
}
