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


        }
    }
}
