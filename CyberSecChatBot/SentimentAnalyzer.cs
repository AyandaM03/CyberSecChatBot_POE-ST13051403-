using System;
using System.Collections.Generic;

namespace CyberSecChatBot
{
    public class SentimentAnalyzer
    {
        private Random rand = new Random();

        // Keyword groupings for different sentiments
        private readonly string[] worriedKeywords = { "worried", "anxious", "scared", "nervous", "afraid", "fear", "unsure" };
        private readonly string[] happyKeywords = { "happy", "excited", "glad", "awesome", "great", "good", "interested" };
        private readonly string[] confusedKeywords = { "confused", "don't understand", "lost", "stuck", "unclear", "hard" };
        private readonly string[] frustratedKeywords = { "frustrated", "angry", "annoyed", "irritated", "mad", "upset" };

        public string AnalyzeSentiment(string input)
        {
            input = input.ToLower();

            if (ContainsAny(input, worriedKeywords))
            {
                return GetRandomWorriedResponse();
            }
            else if (ContainsAny(input, happyKeywords))
            {
                return GetRandomHappyResponse();
            }
            else if (ContainsAny(input, confusedKeywords))
            {
                return GetRandomConfusedResponse();
            }
            else if (ContainsAny(input, frustratedKeywords))
            {
                return GetRandomFrustratedResponse();
            }

            // Default fallback
            return null; // Return null if no sentiment detected
        }

        private bool ContainsAny(string input, string[] keywords)
        {
            foreach (string keyword in keywords)
            {
                if (input.Contains(keyword))
                    return true;
            }
            return false;
        }

        private string GetRandomWorriedResponse()
        {
            string[] responses = {
                "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe.",
                "You’re not alone. A lot of people feel nervous about online safety. I’m here to guide you through it.",
                "Feeling worried is a good sign that you care about your safety. Let's go through how to protect yourself step-by-step."
            };
            return responses[rand.Next(responses.Length)];
        }

        private string GetRandomHappyResponse()
        {
            string[] responses = {
                "I'm glad to hear you're feeling good! Let’s keep learning about cybersecurity.",
                "Your positive attitude is amazing! Together we can make you even more cyber-savvy.",
                "That’s awesome! Cyber safety doesn’t have to be boring — let's make it fun."
            };
            return responses[rand.Next(responses.Length)];
        }

        private string GetRandomConfusedResponse()
        {
            string[] responses = {
                "That's okay — a lot of people feel this way at first. Let's break it down together.",
                "No worries. I'm here to explain things step by step so it's easy to understand.",
                "Let me help make things clearer. Cybersecurity terms can be tricky at first."
            };
            return responses[rand.Next(responses.Length)];
        }

        private string GetRandomFrustratedResponse()
        {
            string[] responses = {
                "I'm sorry you're feeling this way. Let's take it one step at a time.",
                "I get that this can be annoying sometimes. Let’s work through it calmly.",
                "Don’t worry — I’m here to help ease the frustration. Just let me know what's bothering you."
            };
            return responses[rand.Next(responses.Length)];
        }
    }
}
