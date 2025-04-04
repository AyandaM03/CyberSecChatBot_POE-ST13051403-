using System;
using System.Collections.Generic;

namespace CyberSecChatBot
{
    public class Responses
    {
        private Dictionary<string, string> responses = new Dictionary<string, string>
        {
            { "how are you", "I'm just a bot, but I'm here to help!" },
            { "what’s your purpose", "I educate people on staying safe online!" },
            { "password safety", "Always use strong passwords and enable two-factor authentication!" },
            { "phishing", "Beware of suspicious emails and never click on unknown links!" },
            { "safe browsing", "Ensure websites use HTTPS and avoid public Wi-Fi for sensitive transactions." }
        };

          public string GetResponse(string input)
        {
            if (responses.ContainsKey(input))
            {
                return responses[input];
            }
            return "I didn’t quite understand that. Could you rephrase?";
        }

    }
    }
