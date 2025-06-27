using System.Collections.Generic;

namespace CyberSecChatBot
{
   public class QuizManager
    {public List<Question> Questions { get; private set; } = new List<Question>();
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

            Questions.Add(new Question
            {
                Text = "What is phishing?",
                Options = new List<string> { "A fishing technique", "Fraudulent attempts to steal information", "Software update process", "Network troubleshooting" },
                CorrectIndex = 1,
                Explanation = "Phishing is a fraudulent attempt to obtain sensitive information by pretending to be a trustworthy entity."
            });

            Questions.Add(new Question
            {
                Text = "Which of the following is the strongest password?",
                Options = new List<string> { "password123", "123456", "P@55w0rd!2025", "qwerty" },
                CorrectIndex = 2,
                Explanation = "Strong passwords include uppercase, lowercase, numbers, and special characters."
            });

            Questions.Add(new Question
            {
                Text = "What does two-factor authentication (2FA) provide?",
                Options = new List<string> { "Faster internet", "An extra layer of security", "Free software updates", "Access to public Wi-Fi" },
                CorrectIndex = 1,
                Explanation = "2FA adds an extra layer of security by requiring two forms of verification."
            });

            Questions.Add(new Question
            {
                Text = "True or False: It is safe to use the same password for multiple accounts.",
                Options = new List<string> { "True", "False" },
                CorrectIndex = 1,
                Explanation = "False. Using the same password across accounts increases vulnerability."
            });

            Questions.Add(new Question
            {
                Text = "What is malware?",
                Options = new List<string> { "Malicious software designed to harm your computer", "Antivirus software", "Software that speeds up your device", "A secure firewall" },
                CorrectIndex = 0,
                Explanation = "Malware is software designed to damage or gain unauthorized access to computers."
            });

            Questions.Add(new Question
            {
                Text = "Which of these is NOT a good security practice?",
                Options = new List<string> { "Regularly updating software", "Clicking links from unknown sources", "Using strong passwords", "Enabling automatic backups" },
                CorrectIndex = 1,
                Explanation = "Clicking links from unknown sources can lead to security breaches."
            });

            Questions.Add(new Question
            {
                Text = "What is the purpose of a firewall?",
                Options = new List<string> { "To cook food", "To block unauthorized access", "To increase computer speed", "To save files" },
                CorrectIndex = 1,
                Explanation = "A firewall blocks unauthorized access to your network or computer."
            });

            Questions.Add(new Question
            {
                Text = "Which action helps protect against social engineering attacks?",
                Options = new List<string> { "Sharing passwords", "Verifying identities before sharing information", "Clicking unknown links", "Ignoring security updates" },
                CorrectIndex = 1,
                Explanation = "Always verify identities before sharing sensitive information to avoid social engineering."
            });

            Questions.Add(new Question
            {
                Text = "What should you do if you suspect your account has been compromised?",
                Options = new List<string> { "Ignore it", "Change your password immediately", "Share your password with others", "Uninstall your antivirus" },
                CorrectIndex = 1,
                Explanation = "Changing your password immediately can help protect your account."
            });
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
