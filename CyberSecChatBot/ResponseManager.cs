using System;
using System.Collections.Generic;

namespace CyberSecChatBot
{
    public class ResponseManager
    {
        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "password", new List<string> {
                "Use strong, unique passwords for each account.",
                "Avoid using names or birthdays in your passwords.",
                "Enable two-factor authentication for added security."
            }},
            { "phishing", new List<string> {
                "Don't click on suspicious links in emails.",
                "Verify the sender before responding to emails.",
                "Look out for poor grammar and urgent language in scam emails."
            }},
            { "privacy", new List<string> {
                "Review your social media privacy settings regularly.",
                "Avoid oversharing personal information online.",
                "Use encrypted messaging apps for private chats."
            }},
            { "scam", new List<string> {
                "Never send money to unknown people online.",
                "Scammers often impersonate authority figures.",
                "Check official websites for contact info."
            }},
            { "vpn", new List<string> {
                "Use a VPN to protect your data on public Wi-Fi.",
                "VPNs encrypt your internet traffic.",
                "Choose reputable VPN providers for maximum safety."
            }}
        };

        public string GetRandomResponse(string userInput)
        {
            foreach (var keyword in keywordResponses.Keys)
            {
                if (userInput.Contains(keyword))
                {
                    var responses = keywordResponses[keyword];
                    Random rnd = new Random();
                    return responses[rnd.Next(responses.Count)];
                }
            }
            return "I'm not sure I understood that. Could you try asking differently?";
        }
    }
}
