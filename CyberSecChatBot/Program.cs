using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecChatBot
{
   public  class Program
    {
        static void Main(string[] args)
        {
            // Display ASCII Logo
            Logo.Display();

            // Play Voice Greeting
            PlayNow.PlayGreeting();

            // Start User Interaction
            UserPrompt userPrompt = new UserPrompt();
            userPrompt.StartInteraction();

            UserMemory userMemory = new UserMemory();
            SentimentAnalyzer sentimentAnalyzer = new SentimentAnalyzer();
            ResponseManager responseManager = new ResponseManager();


            TaskA taskA = new TaskA();

            TaskManager taskManager = new TaskManager();

            QuizManager quizManager = new QuizManager();

            NLPHandler nlpHandler = new NLPHandler();

            ActivityLog activityLog = new ActivityLog();

            Question question = new Question();

            AppController appController = new AppController();

            Prompt prompt = new Prompt();
        }
    }
}
