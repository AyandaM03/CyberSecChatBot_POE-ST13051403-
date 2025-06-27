using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberSecChatBot
{
   public  class Program
    {
        static void Main()
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

            AddTaskForm addTaskForm = new AddTaskForm();

            TaskListForm taskListForm = new TaskListForm();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());


        }
    }
}
