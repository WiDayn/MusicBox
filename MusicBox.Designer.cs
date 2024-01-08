using MusicBox.Core.Entity;
using MusicBox.UI;
using MusicBox.UI.Button;
using MusicBox.UI.CustomList;
using MusicBox.UI.CustomPictureBox;
using MusicBox.UI.List;
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
            songPlayButton = new PlayButton();
            PlayButton = new PlayButton();
            EndTimeLabel = new Label();
            MainSplitContainer = new SplitContainer();
            LeftDownPanel = new Panel();
            RecentList = new RecentList();
            LeftTopPanel = new Panel();
            SearchButton = new SearchButton();
            HomeButton = new HomeButton();
            RightTabControl = new BorderlessTabControl();
            ArtistPanel = new Panel();
            homePlayList = new HomePlayList();
            HomePanel = new HomePanel();
            SearchPanel = new SearchPanel();
            AlbumPanel = new Panel();
            songTopPanel = new SongTopPanel();
            LyricsPanel = new LyricsPanel();
            songTitle = new SongTitle();
            AlbumList = new RecentList();
            SingerPanel = new Panel();
            SingerList = new SingerList();
            playTrackBar = new PlayTrackBar();
            NowTimeLabel = new Label();
            SecondTimer = new System.Windows.Forms.Timer(components);
            LeftDownAlbumBox = new PictureBox();
            LeftDownSongNameLabel = new Label();
            LeftDownArtistsNameLabel = new Label();
            NextButton = new NextButton();
            LastButton = new LastButton();
            VolumeTrackBar = new PlayTrackBar();
            volumeButton = new VolumeButton();
            lyricsButton = new LyricsButton();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            LeftDownPanel.SuspendLayout();
            LeftTopPanel.SuspendLayout();
            ArtistPanel.SuspendLayout();
            AlbumPanel.SuspendLayout();
            SingerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LeftDownAlbumBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).BeginInit();
            SuspendLayout();
            // 
            // songPlayButton
            // 
            songPlayButton.BackColor = Color.FromArgb(18, 18, 18);
            songPlayButton.FlatStyle = FlatStyle.Flat;
            songPlayButton.Location = new Point(485, 718);
            songPlayButton.Margin = new Padding(2);
            songPlayButton.Name = "songPlayButton";
            songPlayButton.Size = new Size(50, 50);
            songPlayButton.TabIndex = 1;
            songPlayButton.Text = "Start";
            songPlayButton.UseVisualStyleBackColor = true;
            songPlayButton.Click += SongStartButton_Click;
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
            // MainSplitContainer
            // 
            MainSplitContainer.Location = new Point(5, 0);
            MainSplitContainer.Margin = new Padding(0);
            MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.BackColor = Color.Black;
            MainSplitContainer.Panel1.Controls.Add(LeftDownPanel);
            MainSplitContainer.Panel1.Controls.Add(LeftTopPanel);
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.BackColor = Color.Black;
            MainSplitContainer.Panel2.Controls.Add(RightTabControl);
            MainSplitContainer.Size = new Size(990, 686);
            MainSplitContainer.SplitterDistance = 330;
            MainSplitContainer.SplitterWidth = 1;
            MainSplitContainer.TabIndex = 4;
            MainSplitContainer.SplitterMoved += SplitterMoved_SizeChanged;
            // 
            // LeftDownPanel
            // 
            LeftDownPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LeftDownPanel.BackColor = Color.FromArgb(18, 18, 18);
            LeftDownPanel.Controls.Add(RecentList);
            LeftDownPanel.Location = new Point(7, 155);
            LeftDownPanel.Name = "LeftDownPanel";
            LeftDownPanel.Size = new Size(320, 531);
            LeftDownPanel.TabIndex = 2;
            // 
            // RecentList
            // 
            RecentList.Location = new Point(3, 3);
            RecentList.Name = "RecentList";
            RecentList.Size = new Size(314, 66);
            RecentList.TabIndex = 0;
            // 
            // LeftTopPanel
            // 
            LeftTopPanel.BackColor = Color.FromArgb(18, 18, 18);
            LeftTopPanel.Controls.Add(SearchButton);
            LeftTopPanel.Controls.Add(HomeButton);
            LeftTopPanel.Location = new Point(5, 0);
            LeftTopPanel.Name = "LeftTopPanel";
            LeftTopPanel.Size = new Size(330, 130);
            LeftTopPanel.TabIndex = 1;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.FromArgb(18, 18, 18);
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            SearchButton.ForeColor = Color.White;
            SearchButton.Location = new Point(14, 79);
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
            HomeButton.Location = new Point(14, 13);
            HomeButton.Name = "HomeButton";
            HomeButton.Size = new Size(50, 35);
            HomeButton.TabIndex = 0;
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // RightTabControl
            // 
            RightTabControl.Location = new Point(3, 3);
            RightTabControl.Name = "RightTabControl";
            RightTabControl.Size = new Size(96, 100);
            RightTabControl.TabIndex = 1;
            // 
            // ArtistPanel
            // 
            ArtistPanel.BackColor = Color.FromArgb(18, 18, 18);
            ArtistPanel.Controls.Add(homePlayList);
            ArtistPanel.Location = new Point(0, 0);
            ArtistPanel.Margin = new Padding(0);
            ArtistPanel.Name = "ArtistPanel";
            ArtistPanel.Size = new Size(200, 100);
            ArtistPanel.TabIndex = 1;
            // 
            // homePlayList
            // 
            homePlayList.Location = new Point(0, 0);
            homePlayList.Name = "homePlayList";
            homePlayList.Size = new Size(314, 66);
            homePlayList.TabIndex = 0;
            // 
            // HomePanel
            // 
            HomePanel.BackColor = Color.FromArgb(18, 18, 18);
            HomePanel.Dock = DockStyle.Fill;
            HomePanel.Location = new Point(0, 0);
            HomePanel.Margin = new Padding(0);
            HomePanel.Name = "HomePanel";
            HomePanel.Size = new Size(200, 100);
            HomePanel.TabIndex = 0;
            // 
            // SearchPanel
            // 
            SearchPanel.BackColor = Color.FromArgb(18, 18, 18);
            SearchPanel.Dock = DockStyle.Fill;
            SearchPanel.Location = new Point(0, 0);
            SearchPanel.Margin = new Padding(0);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(200, 100);
            SearchPanel.TabIndex = 0;
            // 
            // AlbumPanel
            // 
            AlbumPanel.BackColor = Color.FromArgb(18, 18, 18);
            AlbumPanel.Controls.Add(songTopPanel);
            AlbumPanel.Controls.Add(songPlayButton);
            AlbumPanel.Controls.Add(songTitle);
            AlbumPanel.Controls.Add(AlbumList);
            AlbumPanel.Location = new Point(0, 0);
            AlbumPanel.Margin = new Padding(0);
            AlbumPanel.Name = "AlbumPanel";
            AlbumPanel.Size = new Size(96, 100);
            AlbumPanel.TabIndex = 2;
            // 
            // songTopPanel
            // 
            songTopPanel.Location = new Point(0, 0);
            songTopPanel.Name = "songTopPanel";
            songTopPanel.Size = new Size(96, 100);
            songTopPanel.TabIndex = 0;
            // 
            // songTitle
            // 
            songTitle.Location = new Point(0, 0);
            songTitle.Name = "songTitle";
            songTitle.Size = new Size(150, 150);
            songTitle.TabIndex = 2;
            // 
            // AlbumList
            // 
            AlbumList.Location = new Point(0, 100);
            AlbumList.Name = "AlbumList";
            AlbumList.Size = new Size(96, 100);
            AlbumList.TabIndex = 0;
            // 
            // SingerPanel
            // 
            SingerPanel.BackColor = Color.FromArgb(18, 18, 18);
            SingerPanel.Controls.Add(SingerList);
            SingerPanel.Dock = DockStyle.Fill;
            SingerPanel.Location = new Point(0, 0);
            SingerPanel.Margin = new Padding(0);
            SingerPanel.Name = "SingerPanel";
            SingerPanel.Size = new Size(96, 100);
            SingerPanel.TabIndex = 3;
            // 
            // SingerList
            // 
            SingerList.AutoScroll = true;
            SingerList.BackColor = Color.FromArgb(18, 18, 18);
            SingerList.Dock = DockStyle.Fill;
            SingerList.FlowDirection = FlowDirection.TopDown;
            SingerList.Location = new Point(0, 0);
            SingerList.Name = "SingerList";
            SingerList.Size = new Size(96, 100);
            SingerList.TabIndex = 0;
            SingerList.WrapContents = false;
            // 
            // playTrackBar
            // 
            playTrackBar.AutoSize = false;
            playTrackBar.BackColor = Color.Black;
            playTrackBar.Location = new Point(357, 758);
            playTrackBar.Maximum = 100;
            playTrackBar.Name = "playTrackBar";
            playTrackBar.Size = new Size(104, 45);
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
            VolumeTrackBar.Size = new Size(115, 10);
            VolumeTrackBar.TabIndex = 10;
            VolumeTrackBar.ScrollChanged += VolumeTrackBar_Scroll;
            // 
            // volumeButton
            // 
            volumeButton.BackColor = Color.Black;
            volumeButton.FlatStyle = FlatStyle.Flat;
            volumeButton.Location = new Point(834, 725);
            volumeButton.Name = "volumeButton";
            volumeButton.Size = new Size(32, 37);
            volumeButton.TabIndex = 11;
            volumeButton.UseVisualStyleBackColor = true;
            // 
            // lyricsButton
            // 
            lyricsButton.BackColor = Color.Black;
            lyricsButton.FlatStyle = FlatStyle.Flat;
            lyricsButton.Location = new Point(834, 725);
            lyricsButton.Name = "lyricsButton";
            lyricsButton.Size = new Size(32, 37);
            lyricsButton.TabIndex = 12;
            lyricsButton.UseVisualStyleBackColor = true;
            lyricsButton.Click += Geci_Click;

            // 
            // MusicBox
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(998, 771);
            Controls.Add(volumeButton);
            Controls.Add(lyricsButton);
            Controls.Add(VolumeTrackBar);
            Controls.Add(LeftDownArtistsNameLabel);
            Controls.Add(LeftDownSongNameLabel);
            Controls.Add(LeftDownAlbumBox);
            Controls.Add(LastButton);
            Controls.Add(NextButton);
            Controls.Add(NowTimeLabel);
            Controls.Add(playTrackBar);
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
            LeftDownPanel.ResumeLayout(false);
            LeftTopPanel.ResumeLayout(false);
            ArtistPanel.ResumeLayout(false);
            AlbumPanel.ResumeLayout(false);
            SingerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)playTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)LeftDownAlbumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PlayButton PlayButton;
        private PlayButton songPlayButton;
        private Label EndTimeLabel;
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
        private PlayTrackBar VolumeTrackBar;
        private RecentList AlbumList;
        private RecentList RecentList;
        private Panel LeftTopPanel;
        private Panel LeftDownPanel;
        private DataGridView alumdataGridView;
        private BorderlessTabControl RightTabControl;
        private Panel AlbumPanel;
        private Panel ArtistPanel;
        private SearchPanel SearchPanel;
        private SongTitle songTitle;
        private SongTopPanel songTopPanel;
        private LyricsPanel LyricsPanel;
        private HomePlayList homePlayList;
        private VolumeButton volumeButton;
        private Panel SingerPanel;
        private HomePanel HomePanel;
        private SingerList SingerList;
        private LyricsButton lyricsButton;
    }
}
