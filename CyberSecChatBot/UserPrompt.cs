using System;
using System.Threading;

namespace CyberSecChatBot
{
    public class UserPrompt
    {
        private string user_name = string.Empty;
        private string user_asking = string.Empty;

        private UserMemory userMemory = new UserMemory();
        private SentimentAnalyzer sentimentAnalyzer = new SentimentAnalyzer();
        private ResponseManager responseManager = new ResponseManager();

        public void StartInteraction()
        {
            // Clear screen and set up header
            Console.Clear();
            PrintDivider();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  Welcome to your personalised AI ChatBot ;-) ");
            PrintDivider();
            Console.ResetColor();

            // Ask for user's name
            Console.ForegroundColor = ConsoleColor.Magenta;
            TypeEffect("ChatBot: Hello! What's your name?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("You: ");
            Console.ForegroundColor = ConsoleColor.White;
            user_name = Console.ReadLine();
            userMemory.SaveUserData("name", user_name);
            Console.WriteLine();

            // Greet the user
            Console.ForegroundColor = ConsoleColor.Magenta;
            TypeEffect($"ChatBot: Hey {user_name}, how can I help you today? <3");
            Console.ResetColor();
            Console.WriteLine();

            // Start the chatbot conversation
            StartConversation();
        }

        private void StartConversation()
        {
            Responses responseHandler = new Responses();

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{user_name} <3: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                user_asking = Console.ReadLine()?.Trim().ToLower();

                if (user_asking != "exit")
                {
                    string sentiment = sentimentAnalyzer.AnalyzeSentiment(user_asking);

                    if (sentiment == "worried")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypeEffect("ChatBot: It's okay to feel worried. I'm here to help you stay safe online.");
                    }
                    else if (sentiment == "happy")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypeEffect("ChatBot: Love that energy! Let’s learn more about cybersecurity!");
                    }
                    else
                    {
                        string response = responseManager.GetRandomResponse(user_asking);

                        // Save topic memory
                        if (user_asking.Contains("privacy") || user_asking.Contains("password") || user_asking.Contains("phishing"))
                        {
                            userMemory.SaveUserData("topic", user_asking);
                        }

                        if (user_asking.Contains("remind me") || user_asking.Contains("remember"))
                        {
                            string savedTopic = userMemory.GetUserData("topic");
                            if (!string.IsNullOrEmpty(savedTopic))
                            {
                                TypeEffect($"ChatBot: You mentioned interest in '{savedTopic}'. Let’s explore that more.");
                            }
                            else
                            {
                                TypeEffect("ChatBot: I don't remember you mentioning a topic yet.");
                            }
                        }
                        else
                        {
                            TypeEffect("ChatBot: " + response);
                        }
                    }

                    Console.ResetColor();
                }

            } while (user_asking != "exit");

            Answer(user_asking);
        }

        private void Answer(string asked)
        {
            if (asked == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                TypeEffect("ChatBot: Goodbye! Stay safe online!");
                Console.ResetColor();
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        // Section divider method
        private void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("====================================================");
            Console.ResetColor();
        }

        // Typing effect method
        private void TypeEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20);  // Delay per character (20ms)
            }
            Console.WriteLine();
        }
    }
}



