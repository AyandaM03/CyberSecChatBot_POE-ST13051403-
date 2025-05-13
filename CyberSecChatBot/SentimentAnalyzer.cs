using System;

namespace CyberSecChatBot
{
    public class SentimentAnalyzer
    {
        // Simple sentiment analysis (could be enhanced further)
        public string AnalyzeSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared"))
            {
                return "worried";
            }
            else if (input.Contains("happy") || input.Contains("great"))
            {
                return "happy";
            }
            else if (input.Contains("confused"))
            {
                return "confused";
            }
            return "neutral"; // Default sentiment
        }
    }
}
