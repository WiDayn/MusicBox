using MusicBox.UI.CustomButton;
using MusicBox.UI.CustomTextBox;
using System.Runtime.InteropServices;

namespace MusicBox
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            AccountTextBox = new RoundedTextBox();
            LoginButton = new RoundedPanelButton();
            label1 = new Label();
            PasswordTextBox = new RoundedTextBox();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 134);
            UsernameLabel.ForeColor = Color.White;
            UsernameLabel.Location = new Point(64, 142);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(129, 19);
            UsernameLabel.TabIndex = 0;
            UsernameLabel.Text = "电子邮件或用户名";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 134);
            PasswordLabel.ForeColor = Color.White;
            PasswordLabel.Location = new Point(64, 225);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(39, 19);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "密码";
            // 
            // AccountTextBox
            // 
            AccountTextBox.BackColor = Color.Black;
            AccountTextBox.Location = new Point(64, 182);
            AccountTextBox.Name = "AccountTextBox";
            AccountTextBox.Padding = new Padding(2);
            AccountTextBox.Size = new Size(247, 20);
            AccountTextBox.TabIndex = 2;
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.FromArgb(1, 183, 70);
            LoginButton.Location = new Point(131, 318);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(100, 35);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "button1";
            LoginButton.ButtonClick += LoginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 30F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, 34);
            label1.Name = "label1";
            label1.Size = new Size(338, 52);
            label1.TabIndex = 5;
            label1.Text = "登录到MusicBox";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BackColor = Color.Black;
            PasswordTextBox.Location = new Point(64, 264);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Padding = new Padding(2);
            PasswordTextBox.Size = new Size(247, 20);
            PasswordTextBox.TabIndex = 6;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(384, 411);
            Controls.Add(PasswordTextBox);
            Controls.Add(label1);
            Controls.Add(LoginButton);
            Controls.Add(AccountTextBox);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsernameLabel;
        private Label PasswordLabel;
        private RoundedTextBox AccountTextBox;
        private RoundedPanelButton LoginButton;
        private Label label1;
        private RoundedTextBox PasswordTextBox;
    }
}