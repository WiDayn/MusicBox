using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using MusicBox.API;
using MusicBox.Core.Dtos;
using MusicBox.Core.PlayBack.Player;
using MusicBox.UI.CustomPictureBox;
using MusicBox.UI.List;
using static MusicBox.Core.Dtos.Album;
using static MusicBox.Core.Dtos.Artist;

namespace MusicBox.UI.Button
{
    public class SongButton : UserControl
    {
        public int SongID { get; set; }
        public int ArtistID { get; set; }
        public int AlbumID { get; set; }
        private Label labelIndex;
        private PictureBox pictureBox;
        private Label Title;
        private Label ArtistName;
        private Label LabelAlbum;
        private Label LabelDuration;
        private PictureBox pictureBoxLove;
        private bool MouseOn = false;

        public AlbumInfoResponse AlbumInfoResponse;
        public ArtistInfoResponse ArtistInfoResponse;

        public SongButton(int songID, int artistID, int albumID)
        {
            this.SongID = songID;
            this.ArtistID = artistID;
            this.AlbumID = albumID;
            InitializeControls();
        }

        private void InitializeControls()
        {
            // 序号标签
            labelIndex = new Label
            {
                AutoSize = true,
                Location = new Point((int)(Height * (1 / 10.0)), (int)(Height * (1 / 7.0))),
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
            };
            this.Controls.Add(labelIndex);

            // 创建并设置 PictureBox
            pictureBox = new PictureBox
            {
                Size = new Size((int)(Height * (3 / 10.0)), (int)(Height * (3 / 10.0))),
                Location = new Point((int)(Height * (1 / 2.0)), (int)(Height * (1 / 20.0))),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(pictureBox);

            // 创建并设置 Title Label
            Title = new Label
            {
                Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point((int)(Height * (9 / 10.0)), (int)(Height * (1 / 20.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(Title);

            // 创建并设置 Description Label
            ArtistName = new Label
            {
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                AutoSize = true,
                Location = new Point((int)(Height * (9 / 10.0)), (int)(Height * ( 1 / 5.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(ArtistName);

            // 专辑标签
            LabelAlbum = new Label
            {
                AutoSize = true,
                Location = new Point(Width * 2, (int)(Height * (1 / 7.0))),
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
            };
            this.Controls.Add(LabelAlbum);

            // 创建并设置时长图标 PictureBox
            pictureBoxLove = new PictureBox
            {
                Size = new Size(35,35), // 或者任何适合的大小
                Location = new Point(Width * 3, (int)(Height * (1 / 7.0))), // 调整位置以适合您的布局
                BackColor = Color.Transparent
            };
            pictureBoxLove.Paint += PictureBoxLove_Paint;
            // 添加鼠标事件处理器
            pictureBoxLove.MouseEnter += (sender, e) => { pictureBoxLove.Invalidate(); };
            pictureBoxLove.MouseLeave += (sender, e) => { pictureBoxLove.Invalidate(); };
            pictureBoxLove.Click += PictureBoxLove_Click;


            this.Controls.Add(pictureBoxLove);

            // 时长标签
            LabelDuration = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                Location = new Point(Width * 3, (int)(Height * (1 / 7.0))),
            };
            this.Controls.Add(LabelDuration);


            this.SizeChanged += SizeChangedHandler;

            this.MouseEnter += new EventHandler(SongButton_MouseEnter);
            this.MouseLeave += new EventHandler(SongButton_MouseLeave);
            LabelAlbum.MouseEnter += new EventHandler(LabelAlbum_MouseEnter);
            LabelAlbum.MouseLeave += new EventHandler(LabelAlbum_MouseLeave);
            ArtistName.MouseEnter += new EventHandler(ArtistName_MouseEnter);
            ArtistName.MouseLeave += new EventHandler(ArtistName_MouseLeave);
            this.MouseDoubleClick += new MouseEventHandler(SongButton_DoubleClick);
            labelIndex.DoubleClick += new EventHandler(SongButton_DoubleClick);
            Title.DoubleClick += new EventHandler(SongButton_DoubleClick);
            ArtistName.Click += new EventHandler(ArtistName_Click);
            LabelAlbum.Click += new EventHandler(Album_Click);
            LabelDuration.DoubleClick += new EventHandler(SongButton_DoubleClick);
        }

        protected override async void OnLoad(EventArgs e)
        {
            AlbumInfoResponse = await AlbumAPI.GetAlbumInfoAsync(AlbumID);
            ArtistInfoResponse = await ArtistAPI.GetArtistInfoAsync(ArtistID);
            base.OnLoad(e);
        }

        private async void Album_Click(object sender, EventArgs e)
        {
            Program.DefaultAlbumList.Panel.Controls.Clear();
            Program.AblumPlayingSongTopPanel.SetSongTop(Properties.Resources.External_URL + "/Album/" + AlbumInfoResponse.Data.ArtistName + "-" + AlbumInfoResponse.Data.Album.Title + "/cover.jpg", "专辑", AlbumInfoResponse.Data.Album.Title, AlbumInfoResponse.Data.ArtistName + " • " + AlbumInfoResponse.Data.Songs.Count.ToString() + "首歌曲");
            int i = 1;
            foreach (var song in AlbumInfoResponse.Data.Songs)
            {
                // 专辑封面的位置是固定的
                Program.DefaultAlbumList.AddTrackData((i++).ToString(), Properties.Resources.External_URL + "/Album/" + AlbumInfoResponse.Data.ArtistName + "-" + AlbumInfoResponse.Data.Album.Title + "/cover.jpg",
                    song.SongID, AlbumInfoResponse.Data.Album.ArtistID, song.AlbumID, song.Title, AlbumInfoResponse.Data.ArtistName, AlbumInfoResponse.Data.Album.Title, song.Duration.ToString());
            }
            Program.DefaultRightTabControl.SwitchToPanel(0);
        }

        private async void ArtistName_Click(object sender, EventArgs e)
        {
            Program.DefaultSingerList.SongPanel.Panel.Controls.Clear();
            Program.DefaultSingerList.AlbumPanel.AlbumPanel.Controls.Clear();
            Program.DefaultSingerList.SetSongTop(Properties.Resources.External_URL + "/Artist/" + ArtistInfoResponse.Data.Artist.Name + ".jpg", "歌手", ArtistInfoResponse.Data.Artist.Name, ArtistInfoResponse.Data.Artist.Name + " • " + ArtistInfoResponse.Data.Albums.Count.ToString() + "张专辑");
            int i = 1;
            foreach (var song in ArtistInfoResponse.Data.TopSongs)
            {
                // 专辑封面的位置是固定的
                foreach (var album in ArtistInfoResponse.Data.Albums)
                {
                    if (song.AlbumID == album.AlbumID)
                    {
                        Program.DefaultSingerList.AddTrackData((i++).ToString(), Properties.Resources.External_URL + "/Album/" + ArtistInfoResponse.Data.Artist.Name + "-" + album.Title + "/cover.jpg",
                            song.SongID, ArtistInfoResponse.Data.Artist.ArtistID, song.AlbumID, song.Title, ArtistInfoResponse.Data.Artist.Name, album.Title, song.Duration.ToString());
                    }
                }
            }
            Program.DefaultSingerList.SongPanel.Height = 70 * ArtistInfoResponse.Data.TopSongs.Count();
            foreach (var album in ArtistInfoResponse.Data.Albums)
            {
                Program.DefaultSingerList.AddHomePlayListButton(album.AlbumID, "Album");
            }
            Program.DefaultSingerList.AlbumPanel.Height = 260 * ArtistInfoResponse.Data.Albums.Count();
            Program.DefaultRightTabControl.SwitchToPanel(2);
        }

        private async void PictureBoxLove_Click(object sender, EventArgs e)
        {
            foreach(var songInfo in UserAPI.favoriteResponse.Data.SongInfos)
            {
                if(songInfo.SongID == SongID)
                {
                    _ = UserAPI.RemoveFavoriteSongAsync(songInfo.SongID);
                    UserAPI.favoriteResponse.Data.SongInfos.Remove(songInfo);
                    ((RecentButton)Program.DefaultRecentList.Panel.Controls[0]).ReloadDescriptionText();
                    return;
                }
            }
            _ = UserAPI.AddFavoriteSongAsync(SongID);
            UserAPI.favoriteResponse = await ListAPI.GetFavoriteSongsAsync();
            ((RecentButton)Program.DefaultRecentList.Panel.Controls[0]).ReloadDescriptionText();
            Debug.WriteLine(UserAPI.favoriteResponse.Data.SongInfos.Count);
        }

        private void PictureBoxLove_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 鼠标悬停时使用白色，否则使用灰色
            Color heartColor = (pictureBoxLove.ClientRectangle.Contains(pictureBoxLove.PointToClient(Cursor.Position))) ? Color.White : Color.Gray;
            foreach (var songInfo in UserAPI.favoriteResponse.Data.SongInfos)
            {
                if (songInfo.SongID == SongID)
                {
                    heartColor = Color.Green;
                }
            }
            using (Pen heartPen = new Pen(heartColor, 2))
            {
                // 创建一个新的GraphicsPath来绘制爱心
                using (GraphicsPath path = new GraphicsPath())
                {
                    // 计算爱心的大小和位置
                    int size = Math.Min(pictureBoxLove.Width / 2, pictureBoxLove.Height / 2);
                    int x = pictureBoxLove.Width / 2;
                    int y = pictureBoxLove.Height / 2;

                    // 控制点的偏移量，用于调整爱心的形状
                    int controlOffset = size / 4;

                    // 使用三次贝塞尔曲线绘制爱心形状
                    path.AddBezier(x, y - size / 2, x - controlOffset, y - size, x - size, y - size / 2, x, y+ size / 4);
                    path.AddBezier(x, y+ size / 4, x + size, y - size / 2, x + controlOffset, y - size, x, y - size / 2);


                    // 绘制爱心形状
                    g.DrawPath(heartPen, path);
                }
            }
        }

        private void SongButton_DoubleClick(object sender, EventArgs e)
        {
            Debug.WriteLine($"Add song to playlist: SongID: {SongID} TitleText: {TitleText} - {ArtistID}");
            Program.musicPlayer.AddSongToListFront(new Core.Entity.Song(SongID, TitleText, ArtistID, ArtistNameText, AlbumID, AlbumText, Properties.Resources.External_URL + "/Album/" + ArtistNameText + "-" + AlbumText + "/" + TitleText + ".flac"));
            Program.musicPlayer.PlayInOrder();
            if (Program.PlayButton.isPlaying)
                Program.PlayButton.ToggleShape();
            if (Program.DownPlayButton.isPlaying)
                Program.DownPlayButton.ToggleShape();
        }

        private void LabelAlbum_MouseEnter(object sender, EventArgs e)
        {
            Debug.WriteLine(1);
            LabelAlbum.ForeColor = Color.FromArgb(LabelAlbum.ForeColor.R + 40, LabelAlbum.ForeColor.G + 40, LabelAlbum.ForeColor.B + 40);
            LabelAlbum.Invalidate();
        }

        private void LabelAlbum_MouseLeave(object sender, EventArgs e)
        {
            LabelAlbum.ForeColor = Color.FromArgb(LabelAlbum.ForeColor.R - 40, LabelAlbum.ForeColor.G - 40, LabelAlbum.ForeColor.B - 40);
            LabelAlbum.Invalidate();
        }

        private void ArtistName_MouseEnter(object sender, EventArgs e)
        {
            ArtistName.ForeColor = Color.FromArgb(ArtistName.ForeColor.R + 40, ArtistName.ForeColor.R + 40, ArtistName.ForeColor.R + 40);
            ArtistName.Invalidate();
        }

        private void ArtistName_MouseLeave(object sender, EventArgs e)
        {
            ArtistName.ForeColor = Color.FromArgb(ArtistName.ForeColor.R - 40, ArtistName.ForeColor.G - 40, ArtistName.ForeColor.B - 40);
            ArtistName.Invalidate();
        }

        private void SongButton_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标停留在TrackBar上时的逻辑
            MouseOn = true;
            BackColor = Color.FromArgb(BackColor.R + 8, BackColor.R + 8, BackColor.R + 8);
            ToggleShape();
        }

        // 当鼠标离开TrackBar时触发的方法
        private void SongButton_MouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开TrackBar时的逻辑
            MouseOn = false;
            BackColor = Color.FromArgb(BackColor.R - 8, BackColor.R - 8, BackColor.R - 8);
            ToggleShape();
        }

        // 公共属性允许外部访问和设置控件的文本
        public string Index
        {
            get => labelIndex.Text;
            set => labelIndex.Text = value;
        }

        // 公共属性设置图片
        public Image Image
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }

        public string TitleText
        {
            get => Title.Text;
            set => Title.Text = value;
        }

        public string ArtistNameText
        {
            get => ArtistName.Text;
            set => ArtistName.Text = value;
        }

        public string AlbumText
        {
            get => LabelAlbum.Text;
            set => LabelAlbum.Text = value;
        }

        public string Duration
        {
            get => LabelDuration.Text;
            set => LabelDuration.Text = value;
        }

        // 当鼠标点击时触发
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            // 修改背景颜色
            BackColor = Color.FromArgb(26, 26, 26);
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            LabelAlbum.Location = new Point(Width / 2, (int)(Height * (5 / 14.0)));
            pictureBoxLove.Location = new Point(Width * 13 / 18, (int)(Height * (2 / 7.0)));
            LabelDuration.Location = new Point(Width * 8 / 9, (int)(Height * (5 / 14.0)));
        }

        public void ToggleShape()
        {
            Invalidate();
        }
    }
}
