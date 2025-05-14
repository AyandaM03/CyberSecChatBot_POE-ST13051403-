namespace CyberSecChatBot
{
    public class SentimentAnalyzer
    {
        public string AnalyzeSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid"))
                return "worried";

            if (input.Contains("happy") || input.Contains("great") || input.Contains("awesome"))
                return "happy";

            return "neutral";
        }
    }
}
