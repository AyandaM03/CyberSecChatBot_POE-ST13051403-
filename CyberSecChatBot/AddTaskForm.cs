using System;
using System.Drawing;
using System.Windows.Forms;

namespace CyberSecChatBot
{
    public class AddTaskForm : Form
    {
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblReminder;
        private DateTimePicker dtpReminder;
        private CheckBox chkCompleted;
        private Button btnOK;
        private Button btnCancel;

        public string TaskTitle => txtTitle.Text.Trim();
        public DateTime? ReminderDate => dtpReminder.Checked ? dtpReminder.Value : (DateTime?)null;
        public bool IsCompleted => chkCompleted.Checked;

        public AddTaskForm()
        {
            this.Text = "Add New Task";
            this.Size = new Size(400, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                ColumnCount = 2,
                RowCount = 4
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

            // Row 1 - Title
            lblTitle = new Label { Text = "Task Title:", Anchor = AnchorStyles.Left, AutoSize = true };
            txtTitle = new TextBox { Dock = DockStyle.Fill };

            // Row 2 - Reminder Date
            lblReminder = new Label { Text = "Reminder:", Anchor = AnchorStyles.Left, AutoSize = true };
            dtpReminder = new DateTimePicker { Format = DateTimePickerFormat.Short, ShowCheckBox = true, Dock = DockStyle.Fill };

            // Row 3 - Completed
            chkCompleted = new CheckBox { Text = "Mark as completed", Anchor = AnchorStyles.Left };

            // Row 4 - Buttons
            btnOK = new Button { Text = "Add Task", DialogResult = DialogResult.OK, BackColor = Color.SeaGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, BackColor = Color.Gray, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btnOK.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.BorderSize = 0;

            btnOK.Click += BtnOK_Click;

            layout.Controls.Add(lblTitle, 0, 0);
            layout.Controls.Add(txtTitle, 1, 0);

            layout.Controls.Add(lblReminder, 0, 1);
            layout.Controls.Add(dtpReminder, 1, 1);

            layout.Controls.Add(chkCompleted, 1, 2);

            var buttonPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill };
            buttonPanel.Controls.Add(btnOK);
            buttonPanel.Controls.Add(btnCancel);
            layout.Controls.Add(buttonPanel, 1, 3);

            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 25));

            this.Controls.Add(layout);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a task title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
