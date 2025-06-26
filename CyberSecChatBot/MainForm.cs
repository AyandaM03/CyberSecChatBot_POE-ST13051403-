using System;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace CyberSecChatBot
{
    public partial class MainForm : Form
    {
        private AppController appController = new AppController();

        public MainForm()
        {
            InitializeComponent();

            // Hook up button click events
            btnChat.Click += BtnChat_Click;
            btnAddTask.Click += BtnAddTask_Click;
            btnViewTasks.Click += BtnViewTasks_Click;
            btnStartQuiz.Click += BtnStartQuiz_Click;
            btnViewActivityLog.Click += BtnViewActivityLog_Click;

            // Check reminders when the form loads
            CheckAndShowDueReminders();
        }

        private void BtnChat_Click(object sender, EventArgs e)
        {
            string input = PromptInput("Type your message to the chatbot:");
            if (!string.IsNullOrWhiteSpace(input))
            {
                appController.ProcessInput(input);
            }
        }

        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            string input = Prompt.ShowDialog("Enter task title (optionally add 'remind me in 2 days'):", "Add Task");
            if (!string.IsNullOrWhiteSpace(input))
            {
                appController.ProcessInput("add task " + input.ToLower());

                //  Check for due reminders immediately after adding a task
                CheckAndShowDueReminders();
            }
        }


        private void BtnViewTasks_Click(object sender, EventArgs e)
        {
            var tasks = appController.GetAllTasks();
            if (tasks.Count == 0)
            {
                MessageBox.Show("No tasks available.");
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var task in tasks)
            {
                sb.AppendLine($"• {task.Title} {(task.ReminderDate.HasValue ? $"(Reminder: {task.ReminderDate.Value:d})" : "")} {(task.IsCompleted ? "[✓]" : "[ ]")}");
            }

            MessageBox.Show(sb.ToString(), "All Tasks");
        }

        private void BtnStartQuiz_Click(object sender, EventArgs e)
        {
            appController.RunQuizWithUI(AskQuestion);

        }

        private int AskQuestion(string arg1, string[] arg2)
        {
            throw new NotImplementedException();
        }

        private void BtnViewActivityLog_Click(object sender, EventArgs e)
        {
            var logs = appController.GetRecentActivityLogs();

            if (logs.Count == 0)
            {
                MessageBox.Show("No recent activities logged yet.", "Activity Log");
                return;
            }

            string logText = string.Join(Environment.NewLine, logs);
            MessageBox.Show(logText, "Recent Activity Log");
        }


        // Helper method to prompt input via a small dialog box
        private string PromptInput(string message)
        {
            using (Form inputForm = new Form())
            {
                inputForm.Width = 400;
                inputForm.Height = 150;
                inputForm.Text = "Input";

                Label textLabel = new Label() { Left = 10, Top = 20, Text = message, Width = 360 };
                TextBox inputBox = new TextBox() { Left = 10, Top = 50, Width = 360 };
                Button confirmation = new Button() { Text = "OK", Left = 280, Width = 100, Top = 80 };

                string userInput = null;
                confirmation.Click += (sender, e) => { userInput = inputBox.Text; inputForm.Close(); };

                inputForm.Controls.Add(textLabel);
                inputForm.Controls.Add(inputBox);
                inputForm.Controls.Add(confirmation);
                inputForm.AcceptButton = confirmation;

                inputForm.ShowDialog();
                return userInput;
            }
        }
        private void CheckAndShowDueReminders()
        {
            var tasks = appController.GetAllTasks();

            var dueReminders = tasks
                .Where(t => t.ReminderDate.HasValue && t.ReminderDate.Value.Date <= DateTime.Now.Date && !t.IsCompleted)
                .ToList();

            if (dueReminders.Count > 0)
            {
                string alertText = "You have tasks due today or earlier:\n\n";
                foreach (var task in dueReminders)
                {
                    alertText += $"- {task.Title} (Due: {task.ReminderDate.Value:d})\n";
                }

                MessageBox.Show(alertText, "🔔 Reminder Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
