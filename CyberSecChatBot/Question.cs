using System.Collections.Generic;

namespace CyberSecChatBot
{
    internal class Question
    {
            public string Text { get; set; }
            public List<string> Options { get; set; } = new List<string>();
            public int CorrectIndex { get; set; }
            public string Explanation { get; set; }
        }
    }