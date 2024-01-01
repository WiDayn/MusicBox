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
            label2 = new Label();
            SuspendLayout();
            // 
            // MusicBox
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(1600, 1120);
            // 
            // PlayButton
            // 
            PlayButton.BackColor = Color.Black;
            PlayButton.FlatStyle = FlatStyle.Flat;
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(85, 85);
            PlayButton.Location = new Point(ClientSize.Width / 2 - PlayButton.Width / 2,
                                        ClientSize.Height - 100 - PlayButton.Height / 2);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlText;
            label2.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.ForeColor = Color.White;
            label2.Location = new Point(393, 190);
            label2.Name = "label2";
            label2.Size = new Size(210, 25);
            label2.TabIndex = 3;
            label2.Text = "ギターと孤独と蒼い惑星";
            //
            // All setting
            //
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PlayButton);
            Name = "MusicBox";
            Text = "Form1";
            Load += MusicBox_Load;
            SizeChanged += MusicBox_SizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PlayButton PlayButton;
        private Label label1;
        private Label label2;
    }
}
