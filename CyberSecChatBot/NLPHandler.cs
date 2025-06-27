namespace CyberSecChatBot
{
   public class NLPHandler
    {
        public string DetectIntent(string userInput)
        {
            userInput = userInput.ToLower();

            if (userInput.Contains("add task") || userInput.Contains("remind me"))
                return "add_task";

            if (userInput.Contains("start quiz") || userInput.Contains("quiz") || userInput.Contains("cybersecurity game"))
                return "start_quiz";

            if (userInput.Contains("delete task"))
                return "delete_task";

            if (userInput.Contains("show activity") || userInput.Contains("activity log") || userInput.Contains("what have you done"))
                return "show_activity";

            if (userInput.Contains("finish quiz"))
                return "finish_quiz";

            return "general";
        }
    }

}

