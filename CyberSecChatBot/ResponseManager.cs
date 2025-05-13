using System;
using System.Collections.Generic;

namespace CyberSecChatBot
{
    public class ResponseManager
    {
        private Dictionary<string, List<string>> topicResponses = new Dictionary<string, List<string>>()
        {
            { "phishing", new List<string>
                {
                    "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                    "Always check the sender's email address and avoid clicking on suspicious links."
                }
            },
            { "password safety", new List<string>
                {
                    "Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords.",
                    "Enable two-factor authentication for added security on important accounts."
                }
            }
        };

        // Get random response for a specific topic
        public string GetRandomResponse(string topic)
        {
            if (topicResponses.ContainsKey(topic))
            {
                var responses = topicResponses[topic];
                Random rand = new Random();
                return responses[rand.Next(responses.Count)];
            }
            return "Sorry, I don't have information on that topic.";
        }
    }
}
