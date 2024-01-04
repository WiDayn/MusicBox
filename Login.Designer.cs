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
            textBox1 = new RoundedTextBox();
            button1 = new RoundedPanelButton();
            label1 = new Label();
            roundedTextBox1 = new RoundedTextBox();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            UsernameLabel.ForeColor = Color.White;
            UsernameLabel.Location = new Point(64, 142);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(121, 19);
            UsernameLabel.TabIndex = 0;
            UsernameLabel.Text = "电子邮件或用户名";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            PasswordLabel.ForeColor = Color.White;
            PasswordLabel.Location = new Point(64, 225);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(37, 19);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "密码";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.Location = new Point(64, 182);
            textBox1.Name = "textBox1";
            textBox1.Padding = new Padding(2);
            textBox1.Size = new Size(247, 20);
            textBox1.TabIndex = 2;
            textBox1.Load += textBox1_Load;
            // 
            // button1
            // 
            button1.Location = new Point(143, 318);
            button1.Name = "button1";
            button1.Size = new Size(100, 35);
            button1.TabIndex = 4;
            button1.Text = "button1";
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
            // roundedTextBox1
            // 
            roundedTextBox1.BackColor = Color.Black;
            roundedTextBox1.Location = new Point(64, 264);
            roundedTextBox1.Name = "roundedTextBox1";
            roundedTextBox1.Padding = new Padding(2);
            roundedTextBox1.Size = new Size(247, 20);
            roundedTextBox1.TabIndex = 6;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(384, 411);
            Controls.Add(roundedTextBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox1);
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
        private RoundedTextBox textBox1;
        private RoundedPanelButton button1;
        private Label label1;
        private RoundedTextBox roundedTextBox1;
    }
}