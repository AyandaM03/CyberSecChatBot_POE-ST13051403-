using System;using System.Windows.Forms;
namespace CyberSecChatBot
{
    public partial class MainForm : Form
    {
        private AppController _appController = new AppController();

        public MainForm()
        {   InitializeComponent();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
                return;
chatBox.AppendText("You: " + userInput + Environment.NewLine);

            // Handle the input (e.g., "start quiz", "add task", etc.)
            _appController.HandleUserInput(userInput);

            txtUserInput.Clear();
        }
    
    }
}
