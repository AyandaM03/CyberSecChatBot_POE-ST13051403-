namespace CyberSecChatBot
{
    internal class NLPHandler
    {
    
            public string DetectIntent(string userInput)
            {
                userInput = userInput.ToLower();

                if (userInput.Contains("add task")) return "add_task";
                if (userInput.Contains("remind me")) return "add_reminder";
                if (userInput.Contains("quiz")) return "start_quiz";
                if (userInput.Contains("show activity")) return "show_activity";

                return "unknown";
            }
        }
}
