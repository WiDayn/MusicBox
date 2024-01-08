using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using MusicBox.API;
using MusicBox.Core.Dtos;
using MusicBox.Core.PlayBack.Player;
using MusicBox.UI.CustomPictureBox;
using static MusicBox.Core.Dtos.Album;
using static MusicBox.Core.Dtos.Artist;

namespace MusicBox.UI.Button
{
    public class HomePlayListButton : UserControl
    {
        private PictureBox pictureBox;
        private Label title;
        private Label description;

        // 声明一个点击事件
        public event EventHandler ButtonClick;

        public AlbumInfoResponse AlbumInfoResponse;

        public int ID { get; set; }
        public string Type { get; set; }

        public HomePlayListButton(int id, string type)
        {
            // 设置控件的初始大小
            Size = new Size(300, 100);

            // 创建并设置 PictureBox
            pictureBox = new PictureBox
            {
                Size = new Size((int)(Width * (6 / 10.0)), (int)(Width * (6 / 10.0))),
                Location = new Point((int)(Width * (2 / 10.0)), (int)(Height * (1 / 20.0))),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(pictureBox);

            // 创建并设置 Title Label
            title = new Label
            {
                Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(0, (int)(Height * (6 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(title);

            // 创建并设置 Description Label
            description = new Label
            {
                Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                AutoSize = true,
                Location = new Point(0, (int)(Height * (6 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(description);


            this.SizeChanged += SizeChangedHandler;
            this.MouseEnter += new EventHandler(HomePlayListButton_MouseEnter);
            this.MouseLeave += new EventHandler(HomePlayListButton_MouseLeave);
            this.pictureBox.Click += new EventHandler(HomePlayListButton_Click);
            this.title.Click += new EventHandler(HomePlayListButton_Click);
            this.description.Click += new EventHandler(HomePlayListButton_Click);
            this.Click += new EventHandler(HomePlayListButton_Click);
            ID = id;
            Type = type;
        }
        protected override async void OnLoad(EventArgs e)
        {
            if(Type == "Album")
            {
                AlbumInfoResponse = await AlbumAPI.GetAlbumInfoAsync(ID);
                pictureBox.Image = await ImgAPI.LoadImageFromUrlAsync(Properties.Resources.External_URL + "/Album/" + AlbumInfoResponse.Data.ArtistName + "-" + AlbumInfoResponse.Data.Album.Title + "/cover.jpg");
                title.Text = AlbumInfoResponse.Data.Album.Title;
                description.Text = "专辑";
            }
            
            base.OnLoad(e);
        }

        private void HomePlayListButton_Click(object sender, EventArgs e)
        {
            Program.AblumPlayingSongTopPanel.SetSongTop(Properties.Resources.External_URL + "/Album/" + AlbumInfoResponse.Data.ArtistName + "-" + AlbumInfoResponse.Data.Album.Title + "/cover.jpg", "专辑", AlbumInfoResponse.Data.Album.Title, AlbumInfoResponse.Data.ArtistName + " • " + AlbumInfoResponse.Data.Songs.Count.ToString() + "首歌曲");
            int i = 0;
            Program.DefaultAlbumList.Panel.Controls.Clear();
            foreach (var song in AlbumInfoResponse.Data.Songs)
            {
                // 专辑封面的位置是固定的
                Program.DefaultAlbumList.AddTrackData((i++).ToString(), Properties.Resources.External_URL + "/Album/" + AlbumInfoResponse.Data.ArtistName + "-" + AlbumInfoResponse.Data.Album.Title + "/cover.jpg",
                    song.SongID, AlbumInfoResponse.Data.Album.ArtistID , song.AlbumID, song.Title, AlbumInfoResponse.Data.ArtistName, AlbumInfoResponse.Data.Album.Title, song.Duration.ToString());
            }
            Program.DefaultRightTabControl.SwitchToPanel(0);
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            pictureBox.Location = new Point((int)(Width * (3 / 20.0)), (int)(Height * (1 / 40.0)));
            pictureBox.Size = new Size((int)(Width * (13 / 20.0)), (int)(Width * (13 / 20.0)));
            title.Location = new Point((int)(Width * (3 / 20.0)), (int)(Height * (7 / 10.0)));
            description.Location = new Point((int)(Width * (3 / 20.0)), (int)(Height * (8 / 10.0)));
        }

        private void HomePlayListButton_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标停留在TrackBar上时的逻辑
            BackColor = Color.FromArgb(BackColor.R + 8, BackColor.R + 8, BackColor.R + 8);
            ToggleShape();
        }

        // 当鼠标离开TrackBar时触发的方法
        private void HomePlayListButton_MouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开TrackBar时的逻辑
            BackColor = Color.FromArgb(BackColor.R - 8, BackColor.R - 8, BackColor.R - 8);
            ToggleShape();
        }

        public void ToggleShape()
        {
            Invalidate();
        }
    }
}
