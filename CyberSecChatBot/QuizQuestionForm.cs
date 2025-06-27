using System;
using System.Windows.Forms;

namespace CyberSecChatBot
{
   public class QuizQuestionForm : IDisposable
    {
        private string questionText;
        private string[] options;

        public QuizQuestionForm(string questionText, string[] options)
        {
            this.questionText = questionText;
            this.options = options;
        }

        public int SelectedOptionIndex { get; internal set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal DialogResult ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}