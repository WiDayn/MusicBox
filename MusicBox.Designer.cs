using System.Runtime.InteropServices;
using System.Windows.Forms;

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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicBox));
            PlayButton = new PlayButton();
            EndTimeLabel = new Label();
            label2 = new Label();
            MainSplitContainer = new SplitContainer();
            SearchButton = new SearchButton();
            HomeButton = new HomeButton();
            dataGridView1 = new DataGridView();
            title = new DataGridViewTextBoxColumn();
            Album = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            time = new DataGridViewTextBoxColumn();
            playTrackBar = new PlayTrackBar();
            NowTimeLabel = new Label();
            SecondTimer = new System.Windows.Forms.Timer(components);
            LeftDownAlbumBox = new PictureBox();
            LeftDownSongNameLabel = new Label();
            LeftDownArtistsNameLabel = new Label();
            NextButton = new NextButton();
            LastButton = new LastButton();
            VolumeTrackBar = new PlayTrackBar();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LeftDownAlbumBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).BeginInit();
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
            MainSplitContainer.Panel1.Controls.Add(SearchButton);
            MainSplitContainer.Panel1.Controls.Add(HomeButton);
            MainSplitContainer.Panel1.SizeChanged += MainSplitContainer_Panel1_SizeChanged;
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.BackColor = Color.FromArgb(18, 18, 18);
            MainSplitContainer.Panel2.Controls.Add(dataGridView1);
            MainSplitContainer.Panel2.SizeChanged += MainSplitContainer_Panel2_SizeChanged;
            MainSplitContainer.Size = new Size(990, 686);
            MainSplitContainer.SplitterDistance = 330;
            MainSplitContainer.SplitterWidth = 15;
            MainSplitContainer.TabIndex = 4;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.FromArgb(18, 18, 18);
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            SearchButton.ForeColor = Color.White;
            SearchButton.Location = new Point(0, 75);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(50, 35);
            SearchButton.TabIndex = 1;
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // HomeButton
            // 
            HomeButton.BackColor = Color.FromArgb(18, 18, 18);
            HomeButton.FlatStyle = FlatStyle.Flat;
            HomeButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            HomeButton.ForeColor = Color.White;
            HomeButton.Location = new Point(0, 15);
            HomeButton.Name = "HomeButton";
            HomeButton.Size = new Size(50, 35);
            HomeButton.TabIndex = 0;
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(18, 18, 18);
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle6.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            dataGridViewCellStyle6.ForeColor = Color.Gray;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle6.SelectionForeColor = Color.Gray;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { title, Album, date, time });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(18, 18, 18);
            dataGridView1.Location = new Point(7, 252);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.Size = new Size(638, 434);
            dataGridView1.TabIndex = 0;
            // 
            // title
            // 
            dataGridViewCellStyle7.BackColor = Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle7.ForeColor = Color.Gray;
            dataGridViewCellStyle7.SelectionBackColor = Color.White;
            title.DefaultCellStyle = dataGridViewCellStyle7;
            title.HeaderText = "标题";
            title.Name = "title";
            title.Resizable = DataGridViewTriState.False;
            // 
            // Album
            // 
            dataGridViewCellStyle8.BackColor = Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle8.ForeColor = Color.Gray;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            Album.DefaultCellStyle = dataGridViewCellStyle8;
            Album.HeaderText = "专辑";
            Album.Name = "Album";
            Album.Resizable = DataGridViewTriState.False;
            // 
            // date
            // 
            dataGridViewCellStyle9.BackColor = Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle9.ForeColor = Color.Gray;
            dataGridViewCellStyle9.SelectionBackColor = Color.White;
            date.DefaultCellStyle = dataGridViewCellStyle9;
            date.HeaderText = "添加日期";
            date.Name = "date";
            date.Resizable = DataGridViewTriState.False;
            // 
            // time
            // 
            dataGridViewCellStyle10.BackColor = Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle10.ForeColor = Color.Gray;
            dataGridViewCellStyle10.SelectionBackColor = Color.White;
            time.DefaultCellStyle = dataGridViewCellStyle10;
            time.HeaderText = "时长";
            time.Name = "time";
            time.Resizable = DataGridViewTriState.False;
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
            // LeftDownAlbumBox
            // 
            LeftDownAlbumBox.Image = (Image)resources.GetObject("LeftDownAlbumBox.Image");
            LeftDownAlbumBox.Location = new Point(12, 695);
            LeftDownAlbumBox.Name = "LeftDownAlbumBox";
            LeftDownAlbumBox.Size = new Size(60, 60);
            LeftDownAlbumBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LeftDownAlbumBox.TabIndex = 7;
            LeftDownAlbumBox.TabStop = false;
            // 
            // LeftDownSongNameLabel
            // 
            LeftDownSongNameLabel.AutoSize = true;
            LeftDownSongNameLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134);
            LeftDownSongNameLabel.ForeColor = Color.White;
            LeftDownSongNameLabel.Location = new Point(88, 704);
            LeftDownSongNameLabel.Name = "LeftDownSongNameLabel";
            LeftDownSongNameLabel.Size = new Size(51, 19);
            LeftDownSongNameLabel.TabIndex = 8;
            LeftDownSongNameLabel.Text = "label1";
            // 
            // LeftDownArtistsNameLabel
            // 
            LeftDownArtistsNameLabel.AutoSize = true;
            LeftDownArtistsNameLabel.BackColor = SystemColors.ControlText;
            LeftDownArtistsNameLabel.Font = new Font("Microsoft YaHei UI", 7F, FontStyle.Bold, GraphicsUnit.Point, 134);
            LeftDownArtistsNameLabel.ForeColor = Color.FromArgb(114, 114, 114);
            LeftDownArtistsNameLabel.Location = new Point(90, 727);
            LeftDownArtistsNameLabel.Name = "LeftDownArtistsNameLabel";
            LeftDownArtistsNameLabel.Size = new Size(38, 15);
            LeftDownArtistsNameLabel.TabIndex = 9;
            LeftDownArtistsNameLabel.Text = "label1";
            // 
            // NextButton
            // 
            NextButton.BackColor = Color.Black;
            NextButton.FlatStyle = FlatStyle.Flat;
            NextButton.Location = new Point(543, 719);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(30, 34);
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
            LastButton.Size = new Size(30, 34);
            LastButton.TabIndex = 8;
            LastButton.UseVisualStyleBackColor = true;
            LastButton.Click += LastButton_Click;
            // 
            // VolumeTrackBar
            // 
            VolumeTrackBar.AutoSize = false;
            VolumeTrackBar.BackColor = Color.Black;
            VolumeTrackBar.Location = new Point(872, 727);
            VolumeTrackBar.Maximum = 100;
            VolumeTrackBar.Name = "VolumeTrackBar";
            VolumeTrackBar.Size = new Size(115, 5);
            VolumeTrackBar.TabIndex = 10;
            // 
            // MusicBox
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(998, 771);
            Controls.Add(VolumeTrackBar);
            Controls.Add(LeftDownArtistsNameLabel);
            Controls.Add(LeftDownSongNameLabel);
            Controls.Add(LeftDownAlbumBox);
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
            Text = "MusicBox";
            Load += MusicBox_Load;
            SizeChanged += MusicBox_SizeChanged;
            MainSplitContainer.Panel1.ResumeLayout(false);
            MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)playTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)LeftDownAlbumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).EndInit();
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
        private PictureBox LeftDownAlbumBox;
        private Label LeftDownSongNameLabel;
        private Label LeftDownArtistsNameLabel;
        private NextButton NextButton;
        private LastButton LastButton;
        private SearchButton SearchButton;
        private HomeButton HomeButton;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn Album;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn time;
        private PlayTrackBar VolumeTrackBar;
    }
}
