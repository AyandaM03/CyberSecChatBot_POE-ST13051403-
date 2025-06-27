using System.Collections.Generic;

namespace CyberSecChatBot
{
   public class Question
    {
            public string Text { get; set; }
            public List<string> Options { get; set; } = new List<string>();
            public int CorrectIndex { get; set; }
            public string Explanation { get; set; }
        }
    }