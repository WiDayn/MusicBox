﻿using MusicBox.UI;
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicBox));
            PlayButton = new PlayButton();
            EndTimeLabel = new Label();
            MainSplitContainer = new SplitContainer();
            LeftDownPanel = new Panel();
            LeftTopPanel = new Panel();
            SearchButton = new SearchButton();
            HomeButton = new HomeButton();
            AlbumPanel = new Panel();
            AlbumView = new DataGridView();
            num = new DataGridViewTextBoxColumn();
            title = new DataGridViewTextBoxColumn();
            Album = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            time = new DataGridViewTextBoxColumn();
            RightTabControl = new BorderlessTabControl();
            playTrackBar = new PlayTrackBar();
            NowTimeLabel = new Label();
            SecondTimer = new System.Windows.Forms.Timer(components);
            LeftDownAlbumBox = new PictureBox();
            LeftDownSongNameLabel = new Label();
            LeftDownArtistsNameLabel = new Label();
            NextButton = new NextButton();
            LastButton = new LastButton();
            VolumeTrackBar = new PlayTrackBar();
            ArtistPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            LeftTopPanel.SuspendLayout();
            AlbumPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlbumView).BeginInit();
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
            MainSplitContainer.Panel1.SizeChanged += MainSplitContainer_Panel1_SizeChanged;
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.BackColor = Color.Black;
            MainSplitContainer.Panel2.Controls.Add(ArtistPanel);
            MainSplitContainer.Panel2.Controls.Add(AlbumPanel);
            MainSplitContainer.Panel2.Controls.Add(RightTabControl);
            MainSplitContainer.Panel2.SizeChanged += MainSplitContainer_Panel2_SizeChanged;
            MainSplitContainer.Size = new Size(990, 686);
            MainSplitContainer.SplitterDistance = 330;
            MainSplitContainer.SplitterWidth = 1;
            MainSplitContainer.TabIndex = 4;
            MainSplitContainer.SplitterMoved += SplitterMoved_SizeChanged;
            // 
            // LeftDownPanel
            // 
            LeftDownPanel.BackColor = Color.FromArgb(18, 18, 18);
            LeftDownPanel.Location = new Point(7, 155);
            LeftDownPanel.Name = "LeftDownPanel";
            LeftDownPanel.Size = new Size(320, 531);
            LeftDownPanel.TabIndex = 2;
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
            // AlbumPanel
            // 
            AlbumPanel.BackColor = Color.Transparent;
            AlbumPanel.Controls.Add(AlbumView);
            AlbumPanel.Location = new Point(3, 183);
            AlbumPanel.Margin = new Padding(0);
            AlbumPanel.Name = "AlbumPanel";
            AlbumPanel.Size = new Size(200, 186);
            AlbumPanel.TabIndex = 2;
            // 
            // AlbumView
            // 
            AlbumView.AllowUserToResizeRows = false;
            AlbumView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AlbumView.BackgroundColor = Color.FromArgb(18, 18, 18);
            AlbumView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            dataGridViewCellStyle1.ForeColor = Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle1.SelectionForeColor = Color.Gray;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            AlbumView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            AlbumView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AlbumView.Columns.AddRange(new DataGridViewColumn[] { num, title, Album, date, time });
            AlbumView.Cursor = Cursors.Hand;
            AlbumView.EnableHeadersVisualStyles = false;
            AlbumView.GridColor = Color.FromArgb(18, 18, 18);
            AlbumView.Location = new Point(0, 3);
            AlbumView.Name = "AlbumView";
            AlbumView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            AlbumView.RowHeadersVisible = false;
            AlbumView.Size = new Size(165, 100);
            AlbumView.TabIndex = 0;
            // 
            // num
            // 
            dataGridViewCellStyle2.BackColor = Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle2.ForeColor = Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(18, 18, 18);
            num.DefaultCellStyle = dataGridViewCellStyle2;
            num.FillWeight = 15F;
            num.HeaderText = "#";
            num.Name = "num";
            num.ReadOnly = true;
            num.Resizable = DataGridViewTriState.False;
            num.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // title
            // 
            title.DefaultCellStyle = dataGridViewCellStyle2;
            title.HeaderText = "标题";
            title.Name = "title";
            title.ReadOnly = true;
            title.Resizable = DataGridViewTriState.False;
            // 
            // Album
            // 
            Album.DefaultCellStyle = dataGridViewCellStyle2;
            Album.FillWeight = 80F;
            Album.HeaderText = "专辑";
            Album.Name = "Album";
            Album.ReadOnly = true;
            Album.Resizable = DataGridViewTriState.False;
            // 
            // date
            // 
            date.DefaultCellStyle = dataGridViewCellStyle2;
            date.FillWeight = 45F;
            date.HeaderText = "添加日期";
            date.Name = "date";
            date.ReadOnly = true;
            date.Resizable = DataGridViewTriState.False;
            // 
            // time
            // 
            time.DefaultCellStyle = dataGridViewCellStyle2;
            time.FillWeight = 35F;
            time.HeaderText = "时长";
            time.Name = "time";
            time.ReadOnly = true;
            time.Resizable = DataGridViewTriState.False;
            // 
            // RightTabControl
            // 
            RightTabControl.Location = new Point(3, 3);
            RightTabControl.Name = "RightTabControl";
            RightTabControl.Size = new Size(646, 680);
            RightTabControl.TabIndex = 1;
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
            VolumeTrackBar.Size = new Size(115, 10);
            VolumeTrackBar.TabIndex = 10;
            // 
            // ArtistPanel
            // 
            ArtistPanel.Location = new Point(329, 208);
            ArtistPanel.Name = "ArtistPanel";
            ArtistPanel.Size = new Size(200, 100);
            ArtistPanel.TabIndex = 11;
            ArtistPanel.Paint += panel1_Paint;
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
            LeftTopPanel.ResumeLayout(false);
            AlbumPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AlbumView).EndInit();
            ((System.ComponentModel.ISupportInitialize)playTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)LeftDownAlbumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PlayButton PlayButton;
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
        private DataGridViewTextBoxColumn num;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn Album;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn time;
        private PlayTrackBar VolumeTrackBar;
        private Panel LeftTopPanel;
        private Panel LeftDownPanel;
        private DataGridView alumdataGridView;
        private DataGridView AlbumView;
        private BorderlessTabControl RightTabControl;
        private Panel AlbumPanel;
        private Panel ArtistPanel;
    }
}
