using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CyberSecChatBot
{
    public partial class TaskListForm : Form
    {
        private AppController appController;
        private List<TaskA> tasks;

        // Controls
        private ListView listViewTasks;
        private Button btnMarkComplete;
        private Button btnDeleteTask;
        private CheckBox chkShowDueOnly;

        public TaskListForm(AppController controller)
        {
            appController = controller;
            InitializeComponent();
            LoadTasks();
        }

        public TaskListForm()
        {
        }

        private void InitializeComponent()
        {
            this.Text = "Task List";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            listViewTasks = new ListView()
            {
                View = View.Details,
                FullRowSelect = true,
                MultiSelect = false,
                Dock = DockStyle.Top,
                Height = 280
            };

            listViewTasks.Columns.Add("Title", 350);
            listViewTasks.Columns.Add("Reminder Date", 150);
            listViewTasks.Columns.Add("Completed", 80);

            btnMarkComplete = new Button()
            {
                Text = "Toggle Complete",
                Location = new Point(10, 300),
                Width = 120
            };
            btnMarkComplete.Click += BtnMarkComplete_Click;

            btnDeleteTask = new Button()
            {
                Text = "Delete Task",
                Location = new Point(140, 300),
                Width = 120
            };
            btnDeleteTask.Click += BtnDeleteTask_Click;

            chkShowDueOnly = new CheckBox()
            {
                Text = "Show Due Tasks Only",
                Location = new Point(280, 305),
                AutoSize = true
            };
            chkShowDueOnly.CheckedChanged += ChkShowDueOnly_CheckedChanged;

            this.Controls.Add(listViewTasks);
            this.Controls.Add(btnMarkComplete);
            this.Controls.Add(btnDeleteTask);
            this.Controls.Add(chkShowDueOnly);
        }

        private void LoadTasks()
        {
            tasks = appController.GetAllTasks();

            if (chkShowDueOnly.Checked)
            {
                var now = DateTime.Now.Date;
                tasks = tasks.Where(t => t.ReminderDate.HasValue && t.ReminderDate.Value.Date <= now && !t.IsCompleted).ToList();
            }

            listViewTasks.Items.Clear();

            foreach (var task in tasks)
            {
                var item = new ListViewItem(task.Title);
                item.SubItems.Add(task.ReminderDate?.ToShortDateString() ?? "No date");
                item.SubItems.Add(task.IsCompleted ? "Yes" : "No");

                // Style completed tasks visually
                if (task.IsCompleted)
                {
                    item.ForeColor = Color.Gray;
                    item.Font = new Font(item.Font, FontStyle.Strikeout);
                }

                listViewTasks.Items.Add(item);
            }
        }

        private void BtnMarkComplete_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task to toggle completion status.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTitle = listViewTasks.SelectedItems[0].Text;
            var task = tasks.FirstOrDefault(t => t.Title == selectedTitle);
            if (task != null)
            {
                appController.ToggleTaskCompletion(task.Title);
                LoadTasks();
            }
        }

        private void BtnDeleteTask_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTitle = listViewTasks.SelectedItems[0].Text;

            var confirm = MessageBox.Show($"Are you sure you want to delete the task \"{selectedTitle}\"?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                appController.DeleteTask(selectedTitle);
                LoadTasks();
            }
        }

        private void ChkShowDueOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadTasks();
        }
    }
}
