using System.Collections.Generic;

namespace CyberSecChatBot
{
    internal class QuizManager
    {

            public List<Question> Questions { get; private set; } = new List<Question>();
            public int Score { get; private set; } = 0;

            public void LoadQuestions()
            {
                Questions.Add(new Question
                {
                    Text = "What should you do if you receive an email asking for your password?",
                    Options = new List<string> { "Reply", "Delete", "Report as phishing", "Ignore" },
                    CorrectIndex = 2,
                    Explanation = "Correct! Reporting phishing emails helps prevent scams."
                });
                // Add at least 9 more questions similarly
            }

            public bool CheckAnswer(int questionIndex, int selectedOptionIndex, out string explanation)
            {
                var question = Questions[questionIndex];
                explanation = question.Explanation;

                if (selectedOptionIndex == question.CorrectIndex)
                {
                    Score++;
                    return true;
                }
                return false;
            }
        }
    }