using System;
using System.Threading;

namespace CyberSecChatBot
{
    public class UserPrompt
    {
        private string user_name = string.Empty;
        private string user_asking = string.Empty;

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
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    TypeEffect("ChatBot: " + responseHandler.GetResponse(user_asking));
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
                TypeEffect("ChatBot: Goodbye, Have a great day and remeber, Stay safe online!");
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
                Thread.Sleep(20); // Delay per character (20ms)
            }
            Console.WriteLine();
        }
    }
}



