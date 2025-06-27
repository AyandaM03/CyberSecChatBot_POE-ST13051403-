using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CyberSecChatBot
{
    public class AppController
    {
        private NLPHandler _nlpHandler = new NLPHandler();
        private TaskManager _taskManager = new TaskManager();
        private QuizManager _quizManager = new QuizManager();
        private ActivityLog _activityLog = new ActivityLog();
        private ResponseManager _responseManager = new ResponseManager();
        private SentimentAnalyzer _sentimentAnalyzer = new SentimentAnalyzer();
        private UserMemory _userMemory = new UserMemory();
         
        public void ProcessInput(string userInput)
        { }
        // Your existing processing logic here}

        // Public method to get all tasks
        public List<TaskA> GetAllTasks()
        {
            return _taskManager.GetAllTasks();
        }

        public TaskA GetTaskByTitle(string title)
        {
            return _taskManager.GetTaskByTitle(title);
        }


        // Check due reminders and print to console (or can be expanded to UI alerts)
        public void CheckDueReminders()
        {
            foreach (var task in _taskManager.GetAllTasks())
            {
                if (task.ReminderDate.HasValue
                    && task.ReminderDate.Value.Date <= DateTime.Now.Date
                    && !task.IsCompleted)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Reminder: Task \"{task.Title}\" is due today or overdue!");
                    Console.ResetColor();
                }
            }
        }

        // Toggle completion status of a task by title
        public void ToggleTaskCompletion(string taskTitle)
        {
            var task = _taskManager.GetTaskByTitle(taskTitle);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                _activityLog.AddLog($"Task '{taskTitle}' marked as {(task.IsCompleted ? "completed" : "not completed")}.");
            }
        }

        // Delete task by title
        public void DeleteTask(string taskTitle)
        {
            _taskManager.DeleteTask(taskTitle);
            _activityLog.AddLog($"Task '{taskTitle}' deleted.");
        }

        // Get recent activity logs (limit count)
        public List<string> GetRecentActivityLogs()
        {
            return _activityLog.GetRecentLogs(10);
        }

        // Handle user input, detect intent, and route accordingly
        public void HandleUserInput(string userInput)
        { CheckDueReminders();

            userInput = userInput.ToLower(); // Normalize input for easier matching

            if (userInput.Contains("add task") || userInput.Contains("remind me") || userInput.Contains("set reminder"))
            {
                _activityLog.AddLog("Detected NLP command: Add task or reminder.");
                HandleAddTask(userInput);
                return;
            }
            else if (userInput.Contains("quiz") || userInput.Contains("start quiz") || userInput.Contains("play game"))
            {
                _activityLog.AddLog("Detected NLP command: Start quiz.");
                RunQuiz();
                return;
            }
            else if (userInput.Contains("activity") || userInput.Contains("log") || userInput.Contains("what have you done"))
            {
                _activityLog.AddLog("Detected NLP command: Show activity log.");
                ShowActivityLog();
                return;
            }
            else if (userInput.Contains("delete task"))
            {
                _activityLog.AddLog("Detected NLP command: Delete task.");
                HandleDeleteTask(userInput);
                return;
            }
            else if (userInput.Contains("finish quiz") || userInput.Contains("end quiz"))
            {
                _activityLog.AddLog("Detected NLP command: Finish quiz.");
                HandleFinishQuiz();
                return;
            }     HandleGeneralInput(userInput);
        }

        private void RunQuiz()
        {
            throw new NotImplementedException();
        }

        private void HandleAddTask(string userInput)
        {string input = userInput.Replace("add task", "").Replace("remind me", "").Trim();
            DateTime? reminderDate = null; if (userInput.Contains("remind me") || userInput.Contains("reminder"))
            { string[] parts;
                if (userInput.Contains("remind me"))
                    parts = userInput.Split(new[] { "remind me" }, StringSplitOptions.RemoveEmptyEntries);
                else
                    parts = userInput.Split(new[] { "reminder" }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 2)
                {
                    input = parts[0].Trim();
                    string reminderText = parts[1].Trim();
                    reminderDate = ParseReminderDate(reminderText);
                }
            }

            _taskManager.AddTask(input, $"Task added: {input}", reminderDate);
            string logMessage = $"Task added: '{input}'" + (reminderDate.HasValue ? $" (reminder set for {reminderDate.Value:d})." : ".");
            _activityLog.AddLog(logMessage);

            Console.WriteLine($"ChatBot: Task added - '{input}'" + (reminderDate.HasValue ? $", reminder set for {reminderDate.Value:d}" : ""));
        }

        private void HandleDeleteTask(string userInput)
        {
            var title = userInput.Replace("delete task", "").Trim();
            DeleteTask(title);
            Console.WriteLine($"ChatBot: Task deleted - '{title}'");
        }

        private void HandleFinishQuiz()
        {
            _activityLog.AddLog($"Quiz finished with Score: {_quizManager.Score}.");
            Console.WriteLine($"ChatBot: Quiz finished! Your score: {_quizManager.Score}");
        }

        private void HandleGeneralInput(string userInput)
        {
            var sentimentResponse = _sentimentAnalyzer.AnalyzeSentiment(userInput);
            if (!string.IsNullOrEmpty(sentimentResponse))
            {
                Console.WriteLine($"ChatBot: {sentimentResponse}");
                return;
            }

            var response = _responseManager.GetRandomResponse(userInput);
            Console.WriteLine($"ChatBot: {response}");

            if (userInput.Contains("privacy") || userInput.Contains("password") || userInput.Contains("phishing"))
            {
                _userMemory.SaveUserData("topic", userInput);
            }
        }

        private DateTime? ParseReminderDate(string reminderText)
        {
            reminderText = reminderText.ToLower();

            if (reminderText.Contains("in "))
            {
                int number = 0;
                var words = reminderText.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == "in" && i + 2 < words.Length && int.TryParse(words[i + 1], out number))
                    {
                        if (words[i + 2].StartsWith("day"))
                        {
                            return DateTime.Now.AddDays(number);
                        }
                        else if (words[i + 2].StartsWith("hour"))
                        {
                            return DateTime.Now.AddHours(number);
                        }
                    }
                }
            }
            else if (reminderText.Contains("tomorrow"))
            {
                return DateTime.Now.AddDays(1);
            }
            else if (reminderText.Contains("today"))
            {
                return DateTime.Now;
            }
            else if (DateTime.TryParse(reminderText, out DateTime parsedDate))
            {
                return parsedDate;
            }

            return null;
        }

        public void RunQuizWithUI(Func<string, string[], int> askQuestion)
        {
            _quizManager.LoadQuestions();
            _activityLog.AddLog("Quiz started.");

            for (int i = 0; i < _quizManager.Questions.Count; i++)
            {
                var question = _quizManager.Questions[i];

                int selected = askQuestion(question.Text, question.Options.ToArray());

                bool isCorrect = _quizManager.CheckAnswer(i, selected, out string explanation);

                if (isCorrect)
                    MessageBox.Show("✅ Correct!\n" + explanation, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("❌ Incorrect.\n" + explanation, "Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            string final = $"Quiz complete! Your score: {_quizManager.Score} out of {_quizManager.Questions.Count}\n";

            if (_quizManager.Score >= _quizManager.Questions.Count * 0.8)
                final += "🎉 Great job! You’re a cybersecurity pro!";
            else if (_quizManager.Score >= _quizManager.Questions.Count * 0.5)
                final += "👍 Not bad! Keep learning!";
            else
                final += "📚 Keep practicing!";

            MessageBox.Show(final, "Quiz Summary");

            _activityLog.AddLog($"Quiz finished with Score: {_quizManager.Score}.");
        } private void ShowActivityLog()
        {
            var recentLogs = _activityLog.GetRecentLogs(10);

            if (recentLogs.Count == 0)
            {
                Console.WriteLine("\nNo activity logged yet.");
                return;
            }

            Console.WriteLine("\nHere’s a summary of recent activities:");
            foreach (var entry in recentLogs)
            {
                Console.WriteLine(entry);
            }

        }
 private int AskQuestion(string questionText, string[] options)
        {
            using (Form dialog = new Form())
            {
                dialog.Width = 400;
                dialog.Height = 300;
                dialog.Text = "Quiz Question";

                Label lbl = new Label() { Text = questionText, Top = 10, Left = 10, Width = 360 };
                dialog.Controls.Add(lbl);

                List<RadioButton> radioButtons = new List<RadioButton>();
                for (int i = 0; i < options.Length; i++)
                {
                    RadioButton rb = new RadioButton()
                    {
                        Text = options[i],
                        Top = 40 + (i * 30),
                        Left = 20,
                        Width = 350,
                        Tag = i
                    };
                    radioButtons.Add(rb);
                    dialog.Controls.Add(rb);
                }

                Button submit = new Button() { Text = "Submit", Left = 270, Width = 100, Top = 180 };
                submit.DialogResult = DialogResult.OK;
                dialog.Controls.Add(submit);

                dialog.AcceptButton = submit;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var selected = radioButtons.FirstOrDefault(rb => rb.Checked);
                    if (selected != null)
                        return (int)selected.Tag;
                }

                return -1; // default/fallback
            }
        }

        public void AddTaskFromUI(string title, DateTime? reminder, bool completed)
        {
            _taskManager.AddTask(title, $"Task added: {title}", reminder);

            var task = _taskManager.Tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                task.IsCompleted = completed;
            }

            string logMessage = $"Task added: '{title}'" + (reminder.HasValue ? $" (reminder set for {reminder.Value:d})." : ".");
            _activityLog.AddLog(logMessage);

            Console.WriteLine($"ChatBot: Task added - '{title}'" + (reminder.HasValue ? $", reminder set for {reminder.Value:d}" : ""));
        }

        public void UpdateTaskCompletion(string title, bool isCompleted)
        {
            var task = _taskManager.Tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                task.IsCompleted = isCompleted;
            }
        }

        public void LogActivity(string message)
        {
            _activityLog.AddLog(message);
        }
    }
}


