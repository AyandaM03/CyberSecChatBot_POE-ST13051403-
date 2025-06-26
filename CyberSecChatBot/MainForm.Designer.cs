namespace CyberSecChatBot
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // New controls
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnViewTasks;
        private System.Windows.Forms.Button btnStartQuiz;
        private System.Windows.Forms.Button btnViewActivityLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnViewTasks = new System.Windows.Forms.Button();
            this.btnStartQuiz = new System.Windows.Forms.Button();
            this.btnViewActivityLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(384, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CyberSecurity Awareness ChatBot";
            // 
            // btnChat
            // 
            this.btnChat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnChat.Location = new System.Drawing.Point(35, 80);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(160, 40);
            this.btnChat.TabIndex = 1;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = true;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddTask.Location = new System.Drawing.Point(35, 130);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(160, 40);
            this.btnAddTask.TabIndex = 2;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            // 
            // btnViewTasks
            // 
            this.btnViewTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewTasks.Location = new System.Drawing.Point(35, 180);
            this.btnViewTasks.Name = "btnViewTasks";
            this.btnViewTasks.Size = new System.Drawing.Size(160, 40);
            this.btnViewTasks.TabIndex = 3;
            this.btnViewTasks.Text = "View Tasks";
            this.btnViewTasks.UseVisualStyleBackColor = true;
            // 
            // btnStartQuiz
            // 
            this.btnStartQuiz.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStartQuiz.Location = new System.Drawing.Point(35, 230);
            this.btnStartQuiz.Name = "btnStartQuiz";
            this.btnStartQuiz.Size = new System.Drawing.Size(160, 40);
            this.btnStartQuiz.TabIndex = 4;
            this.btnStartQuiz.Text = "Start Quiz";
            this.btnStartQuiz.UseVisualStyleBackColor = true;
            // 
            // btnViewActivityLog
            // 
            this.btnViewActivityLog.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewActivityLog.Location = new System.Drawing.Point(35, 280);
            this.btnViewActivityLog.Name = "btnViewActivityLog";
            this.btnViewActivityLog.Size = new System.Drawing.Size(160, 40);
            this.btnViewActivityLog.TabIndex = 5;
            this.btnViewActivityLog.Text = "View Activity Log";
            this.btnViewActivityLog.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 350);
            this.Controls.Add(this.btnViewActivityLog);
            this.Controls.Add(this.btnStartQuiz);
            this.Controls.Add(this.btnViewTasks);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.Text = "CyberSecurity ChatBot Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
