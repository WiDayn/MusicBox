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
            StopButton = new Button();
            StartButton = new Button();
            SuspendLayout();
            // 
            // StopButton
            // 
            StopButton.Location = new Point(251, 217);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(94, 63);
            StopButton.TabIndex = 0;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_click;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(385, 217);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(110, 63);
            StartButton.TabIndex = 1;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // MusicBox
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StartButton);
            Controls.Add(StopButton);
            Name = "MusicBox";
            Text = "Form1";
            Load += MusicBox_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button StopButton;
        private Button StartButton;
    }
}
