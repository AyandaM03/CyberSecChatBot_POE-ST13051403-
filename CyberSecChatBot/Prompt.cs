using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 400,
            Height = 180,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen
        };

        Label lblText = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
        TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
        Button confirmation = new Button() { Text = "OK", Left = 270, Width = 90, Top = 90 };
        confirmation.Click += (sender, e) => { prompt.Close(); };

        prompt.Controls.Add(lblText);
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(confirmation);
        prompt.AcceptButton = confirmation;

        prompt.ShowDialog();

        return textBox.Text;
    }
}
