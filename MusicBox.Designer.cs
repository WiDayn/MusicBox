using System.Runtime.InteropServices;

namespace MusicBox
{

    partial class MusicBox
    {
        private const int oriClientWidth = 1014;
        private const int oriClientHeight = 810;
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
            components = new System.ComponentModel.Container();
            PlayButton = new PlayButton();
            EndTimeLabel = new Label();
            label2 = new Label();
            MainSplitContainer = new SplitContainer();
            playTrackBar = new PlayTrackBar();
            NowTimeLabel = new Label();
            SecondTimer = new System.Windows.Forms.Timer(components);
            NextButton = new NextButton();
            LastButton = new LastButton();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playTrackBar).BeginInit();
            SuspendLayout();
            // 
            // PlayButton
            // 
            PlayButton.BackColor = Color.Black;
            PlayButton.FlatStyle = FlatStyle.Flat;
            PlayButton.Location = new Point(485, 718);
            PlayButton.Margin = new Padding(2);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(35, 35);
            PlayButton.TabIndex = 1;
            PlayButton.Text = "Start";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += StartButton_Click;
            // 
            // EndTimeLabel
            // 
            EndTimeLabel.AutoSize = true;
            EndTimeLabel.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            EndTimeLabel.ForeColor = Color.FromArgb(178, 178, 178);
            EndTimeLabel.Location = new Point(665, 751);
            EndTimeLabel.Margin = new Padding(2, 0, 2, 0);
            EndTimeLabel.Name = "EndTimeLabel";
            EndTimeLabel.Size = new Size(32, 17);
            EndTimeLabel.TabIndex = 2;
            EndTimeLabel.Text = "4:27";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlText;
            label2.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.ForeColor = Color.White;
            label2.Location = new Point(250, 135);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(140, 17);
            label2.TabIndex = 3;
            label2.Text = "ギターと孤独と蒼い惑星";
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.Location = new Point(5, 0);
            MainSplitContainer.Margin = new Padding(0);
            MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.BackColor = Color.FromArgb(18, 18, 18);
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.BackColor = Color.FromArgb(18, 18, 18);
            MainSplitContainer.Size = new Size(990, 686);
            MainSplitContainer.SplitterDistance = 330;
            MainSplitContainer.SplitterWidth = 15;
            MainSplitContainer.TabIndex = 4;
            // 
            // playTrackBar
            // 
            playTrackBar.AutoSize = false;
            playTrackBar.BackColor = Color.Black;
            playTrackBar.Location = new Point(357, 758);
            playTrackBar.Maximum = 100;
            playTrackBar.Name = "playTrackBar";
            playTrackBar.Size = new Size(294, 10);
            playTrackBar.TabIndex = 5;
            playTrackBar.ScrollChanged += PlayTrackBar_Scroll;
            // 
            // NowTimeLabel
            // 
            NowTimeLabel.AutoSize = true;
            NowTimeLabel.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            NowTimeLabel.ForeColor = Color.FromArgb(178, 178, 178);
            NowTimeLabel.Location = new Point(310, 751);
            NowTimeLabel.Margin = new Padding(2, 0, 2, 0);
            NowTimeLabel.Name = "NowTimeLabel";
            NowTimeLabel.Size = new Size(32, 17);
            NowTimeLabel.TabIndex = 6;
            NowTimeLabel.Text = "4:27";
            // 
            // SecondTimer
            // 
            SecondTimer.Enabled = true;
            SecondTimer.Tick += SecondTimer_Tick;
            // 
            // NextButton
            // 
            NextButton.BackColor = Color.Black;
            NextButton.FlatStyle = FlatStyle.Flat;
            NextButton.Location = new Point(525, 719);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(48, 34);
            NextButton.TabIndex = 7;
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // LastButton
            // 
            LastButton.BackColor = Color.Black;
            LastButton.FlatStyle = FlatStyle.Flat;
            LastButton.Location = new Point(433, 719);
            LastButton.Name = "LastButton";
            LastButton.Size = new Size(47, 34);
            LastButton.TabIndex = 8;
            LastButton.UseVisualStyleBackColor = true;
            LastButton.Click += LastButton_Click;
            // 
            // MusicBox
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(998, 771);
            Controls.Add(LastButton);
            Controls.Add(NextButton);
            Controls.Add(NowTimeLabel);
            Controls.Add(playTrackBar);
            Controls.Add(label2);
            Controls.Add(EndTimeLabel);
            Controls.Add(PlayButton);
            Controls.Add(MainSplitContainer);
            Margin = new Padding(2);
            MinimumSize = new Size(1014, 810);
            Name = "MusicBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += MusicBox_Load;
            SizeChanged += MusicBox_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)playTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PlayButton PlayButton;
        private Label EndTimeLabel;
        private Label label2;
        private SplitContainer MainSplitContainer;
        private PlayTrackBar playTrackBar;
        private Label NowTimeLabel;
        private System.Windows.Forms.Timer SecondTimer;
        private NextButton NextButton;
        private LastButton LastButton;
    }
}
