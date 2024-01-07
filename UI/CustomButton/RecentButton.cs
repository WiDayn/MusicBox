using global::MusicBox.API;
using global::MusicBox.UI.CustomPictureBox;
using MusicBox.Core.Dtos;
using MusicBox.Core.Entity;
using static MusicBox.Core.Dtos.Album;
using static MusicBox.Core.Dtos.Artist;

namespace MusicBox.UI.Button
{
    public class RecentButton : UserControl
    {
        private CircularPictureBox pictureBox;
        private Label Title;
        private Label Description;
        // type: Like,Album,Artist
        public String Type {  get; set; }
        public int ID { get; set; }

        // 声明一个点击事件
        public event EventHandler ButtonClick;

        public AlbumInfoResponse AlbumInfoResponse;
        public ArtistInfoResponse ArtistInfoResponse;

        public RecentButton(string type)
        {
            // 设置控件的初始大小
            Size = new Size(300, 100);
            // 创建并设置 PictureBox
            pictureBox = new CircularPictureBox
            {
                Size = new Size((int)(Height * (6 / 10.0)), (int)(Height * (6 / 10.0))),
                Location = new Point((int)(Height * (1 / 10.0)), (int)(Height * (2 / 10.0))),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(pictureBox);

            // 创建并设置 Label
            Title = new Label
            {
                Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point((int)(Height * (10.5 / 10.0)), (int)(Height * (3 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(Title);

            // 创建并设置 Label
            Description = new Label
            {
                Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                AutoSize = true,
                Location = new Point((int)(Height * (11 / 10.0)), (int)(Height * (6 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(Description);

            this.SizeChanged += SizeChangedHandler;
            this.MouseEnter += new EventHandler(RecentButton_MouseEnter);
            this.MouseLeave += new EventHandler(RecentButton_MouseLeave);
            pictureBox.MouseClick += new MouseEventHandler(RecentButton_MouseClick);
            Title.MouseClick += new MouseEventHandler(RecentButton_MouseClick);
            Description.MouseClick += new MouseEventHandler(RecentButton_MouseClick);
            this.MouseClick += new MouseEventHandler(RecentButton_MouseClick);
            Type = type;
        }

        public void ReloadDescriptionText()
        {
            if (Type == "Like") DescriptionText = $"歌单 • 已喜欢{UserAPI.favoriteResponse.Data.SongInfos.Count}首歌";
        }

        protected override async void OnLoad(EventArgs e)
        {
            if (Type == "Album")
            {
                AlbumInfoResponse = await AlbumAPI.GetAlbumInfoAsync(ID);
                pictureBox.Image = await ImgAPI.LoadImageFromUrlAsync(Properties.Resources.External_URL + "/Album/" + AlbumInfoResponse.Data.ArtistName + "-" + AlbumInfoResponse.Data.Album.Title + "/cover.jpg");
                Title.Text = AlbumInfoResponse.Data.ArtistName;
                Description.Text = "专辑";
            }
            if (Type == "Artist")
            {
                ArtistInfoResponse = await ArtistAPI.GetArtistInfoAsync(ID);
                pictureBox.Image = await ImgAPI.LoadImageFromUrlAsync(Properties.Resources.External_URL + "/Artist/" + ArtistInfoResponse.Data.Artist.Name + ".jpg");
                Title.Text = ArtistInfoResponse.Data.Artist.Name;
                Description.Text = "歌手";
            }
            if (Type == "Like") DescriptionText = $"歌单 • 已喜欢{UserAPI.favoriteResponse.Data.SongInfos.Count}首歌";
            base.OnLoad(e);
        }

        private async void RecentButton_MouseClick(object sender, MouseEventArgs e)
        {
            // TODO: 更新RightTabControl.(0)里的内容
            Program.DefaultAlbumList.Panel.Controls.Clear();
            Program.DefaultSingerList.SongPanel.Panel.Controls.Clear();
            Program.DefaultSingerList.AlbumPanel.AlbumPanel.Controls.Clear();
            int i = 1;
            if (Type == "Like")
            {
                Program.AblumPlayingSongTopPanel.SetSongTopFromIMG(Properties.Resources.MyLove, "歌单", "已点赞的歌", UserAPI.userData.Username + " • " + UserAPI.favoriteResponse.Data.SongInfos.Count.ToString() + "首歌曲");

                foreach (var song in UserAPI.favoriteResponse.Data.SongInfos)
                {
                    // 专辑封面的位置是固定的
                    Program.DefaultAlbumList.AddTrackData((i++).ToString(), true,  Properties.Resources.External_URL + "/Album/" + song.ArtistName + "-" + song.AlbumTitle + "/cover.jpg",
                        song.SongID, song.Title, song.ArtistName, song.AlbumTitle, song.Duration.ToString());
                }
                Program.DefaultRightTabControl.SwitchToPanel(0);
            }
            if (Type == "Album")
            {
                Program.AblumPlayingSongTopPanel.SetSongTop(Properties.Resources.External_URL + "/Album/" + AlbumInfoResponse.Data.ArtistName + "-" + AlbumInfoResponse.Data.Album.Title + "/cover.jpg", "专辑", AlbumInfoResponse.Data.Album.Title, AlbumInfoResponse.Data.ArtistName + " • " + AlbumInfoResponse.Data.Songs.Count.ToString() + "首歌曲");

                foreach (var song in AlbumInfoResponse.Data.Songs)
                {
                    // 专辑封面的位置是固定的
                    Program.DefaultAlbumList.AddTrackData((i++).ToString(), true, Properties.Resources.External_URL + "/Album/" + AlbumInfoResponse.Data.ArtistName + "-" + AlbumInfoResponse.Data.Album.Title + "/cover.jpg",
                        song.SongID, song.Title, AlbumInfoResponse.Data.ArtistName, AlbumInfoResponse.Data.Album.Title, song.Duration.ToString());
                }
                Program.DefaultRightTabControl.SwitchToPanel(0);
            }
            if (Type == "Artist")
            {
                Program.DefaultSingerList.SetSongTop(Properties.Resources.External_URL + "/Artist/" + ArtistInfoResponse.Data.Artist.Name + ".jpg", "歌手", ArtistInfoResponse.Data.Artist.Name, ArtistInfoResponse.Data.Artist.Name + " • " + ArtistInfoResponse.Data.Albums.Count.ToString() + "张专辑");

                foreach (var song in ArtistInfoResponse.Data.TopSongs)
                {
                    // 专辑封面的位置是固定的
                    foreach(var album in ArtistInfoResponse.Data.Albums)
                    {
                        if(song.AlbumID == album.AlbumID)
                        {
                            Program.DefaultSingerList.AddTrackData((i++).ToString(), Properties.Resources.External_URL + "/Album/" + ArtistInfoResponse.Data.Artist.Name + "-" + album.Title + "/cover.jpg",
                                song.SongID, song.Title, ArtistInfoResponse.Data.Artist.Name, album.Title, song.Duration.ToString());
                        }
                    }
                }
                Program.DefaultSingerList.SongPanel.Height = 70 * ArtistInfoResponse.Data.TopSongs.Count();
                foreach (var album in ArtistInfoResponse.Data.Albums)
                {
                    Program.DefaultSingerList.AddHomePlayListButton(Properties.Resources.External_URL + "/Album/" + ArtistInfoResponse.Data.Artist.Name + "-" + album.Title + "/cover.jpg", album.Title, ArtistInfoResponse.Data.Artist.Name);
                }
                Program.DefaultSingerList.AlbumPanel.Height = 260 * ArtistInfoResponse.Data.Albums.Count();
                Program.DefaultRightTabControl.SwitchToPanel(2);
            }
            ButtonClick?.Invoke(this, EventArgs.Empty);
        }
        private void RecentButton_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标停留在TrackBar上时的逻辑
            BackColor = Color.FromArgb(BackColor.R + 8, BackColor.R + 8, BackColor.R + 8);
            ToggleShape();
        }

        // 当鼠标离开TrackBar时触发的方法
        private void RecentButton_MouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开TrackBar时的逻辑
            BackColor = Color.FromArgb(BackColor.R - 8, BackColor.R - 8, BackColor.R - 8);
            ToggleShape();
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            pictureBox.Size = new Size((int)(Height * (6 / 10.0)), (int)(Height * (6 / 10.0)));
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

        public string DescriptionText
        {
            get => Description.Text;
            set => Description.Text = value;
        }

        // 当鼠标点击时触发
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            // 修改背景颜色
            BackColor = Color.FromArgb(26, 26, 26);
        }

        public void ToggleShape()
        {
            Invalidate();
        }
    }

}
