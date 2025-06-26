namespace CyberSecChatBot
{
    internal class NLPHandler
    {
        public string DetectIntent(string userInput)
        {
            userInput = userInput.ToLower();

            // Task-related variations
            if (userInput.Contains("add task") || userInput.Contains("new task") || userInput.Contains("set a task"))
                return "add_task";

            // Reminder-related variations
            if (userInput.Contains("remind me") || userInput.Contains("set reminder") || userInput.Contains("add reminder") || userInput.Contains("reminder"))
                return "add_reminder";

            // Quiz-related variations
            if (userInput.Contains("quiz") || userInput.Contains("start quiz") || userInput.Contains("play quiz") || userInput.Contains("begin quiz"))
                return "start_quiz";

            // Activity log-related variations
            if (userInput.Contains("show activity") || userInput.Contains("activity log") || userInput.Contains("what have you done") || userInput.Contains("show log"))
                return "show_activity";

            return "unknown";
        }
    }
}
