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

            //Handling and storage class
            UserMemory userMemory = new UserMemory();

            //Detector and analyser of the sentimnet of user input 
            SentimentAnalyzer sentimentAnalyzer = new SentimentAnalyzer();

            //For managing random responses for certain topics
            ResponseManager responseManager = new ResponseManager();




        }
    }
