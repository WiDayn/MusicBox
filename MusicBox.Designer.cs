namespace MusicBox
{
    partial class MusicBox
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PlayButton = new PlayButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // PlayButton
            // 
            PlayButton.BackColor = Color.Black;
            PlayButton.FlatStyle = FlatStyle.Flat;
            PlayButton.Location = new Point(332, 312);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(85, 85);
            PlayButton.TabIndex = 1;
            PlayButton.Text = "Start";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += StartButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.ForeColor = Color.FromArgb(178, 178, 178);
            label1.Location = new Point(610, 441);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 2;
            label1.Text = "4:27";
            // 
            // MusicBox
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(821, 523);
            Controls.Add(label1);
            Controls.Add(PlayButton);
            Name = "MusicBox";
            Text = "Form1";
            Load += MusicBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PlayButton PlayButton;
        private Label label1;
    }
}
