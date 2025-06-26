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
        {
            // Your existing processing logic here
            // (You can copy your existing code for ProcessInput here)
        }

        // Public method to get all tasks
        public List<TaskA> GetAllTasks()
        {
            return _taskManager.GetAllTasks();
        }


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

        public List<string> GetRecentActivityLogs()
        {
            return _activityLog.GetRecentLogs(10);
        }


        public void HandleUserInput(string userInput)
        {
            // Check due reminders first
            CheckDueReminders();

            var intent = _nlpHandler.DetectIntent(userInput);

            switch (intent)
            {
                case "add_task":
                    HandleAddTask(userInput);
                    break;

                case "add_reminder":
                    HandleAddTask(userInput);
                    break;

                case "start_quiz":
                    RunQuiz();
                    break;

                case "show_activity":
                    ShowActivityLog();
                    break;

                case "delete_task":
                    HandleDeleteTask(userInput);
                    break;

                case "finish_quiz":
                    HandleFinishQuiz();
                    break;

                default:
                    HandleGeneralInput(userInput);
                    break;
            }
        }

        private void RunQuiz()
        {
            throw new NotImplementedException();
        }

        private void HandleAddTask(string userInput)
        {
            // Remove the trigger keyword
            string input = userInput.Replace("add task", "").Replace("remind me", "").Trim();

            DateTime? reminderDate = null;

            // Check if input contains "remind me" or "reminder"
            if (userInput.Contains("remind me") || userInput.Contains("reminder"))
            {
                // Simple parsing
                string[] parts;
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
            string logMessage = $"Task added: '{input}'" + (reminderDate.HasValue
                ? $" (reminder set for {reminderDate.Value:d})."
                : ".");
            _activityLog.AddLog(logMessage);

            Console.WriteLine($"ChatBot: Task added - '{input}'" + (reminderDate.HasValue ? $", reminder set for {reminderDate.Value:d}" : ""));
        }

        private void HandleDeleteTask(string userInput)
        {
            var title = userInput.Replace("delete task", "").Trim();
            _taskManager.DeleteTask(title);
            _activityLog.AddLog($"Task deleted: '{title}'.");
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
        }


        private void ShowActivityLog()
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


    }
}

