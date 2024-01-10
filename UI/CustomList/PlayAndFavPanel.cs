using MusicBox.API;
using MusicBox.UI.Button;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicBox.UI.CustomList
{
    
    public class PlayAndFavPanel : Panel
    {
        private PictureBox pictureBoxLove;
        public PlayButton songPlayButton;
        public string type;
        public int ID { get; set; }

        public PlayAndFavPanel()
        {
            // 创建并设置时长图标 PictureBox
            pictureBoxLove = new PictureBox
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 30,
                Size = new Size(65, 65), // 或者任何适合的大小
                Location = new Point(60, 2),
                BackColor = Color.Transparent
            };
            pictureBoxLove.Paint += PictureBoxLove_Paint;
            this.Controls.Add(pictureBoxLove);
            songPlayButton = new PlayButton();
            songPlayButton.BackColor = Color.FromArgb(18, 18, 18);
            songPlayButton.FlatStyle = FlatStyle.Flat;
            songPlayButton.Location = new Point(5, 0);
            songPlayButton.Margin = new Padding(2);
            songPlayButton.Name = "songPlayButton";
            songPlayButton.Size = new Size(50, 50);
            songPlayButton.TabIndex = 1;
            songPlayButton.Text = "Start";
            songPlayButton.UseVisualStyleBackColor = true;
            songPlayButton.Click += SongStartButton_Click;
            this.Controls.Add(songPlayButton);
        }

        private void SongStartButton_Click(object sender, EventArgs e)
        {
            if (songPlayButton.isPlaying)
            {
                Program.musicPlayer.ClearPlayList();
                if(type == "Artist")
                {
                    for (int i = Program.DefaultSingerList.SongPanel.Panel.Controls.Count - 1; i >= 0; i--)
                    {
                        if (Program.DefaultSingerList.SongPanel.Panel.Controls[i].GetType() == typeof(SongButton))
                        {
                            SongButton song = (SongButton)Program.DefaultSingerList.SongPanel.Panel.Controls[i];
                            Program.musicPlayer.AddSongToListFront(new Core.Entity.Song(song.SongID, song.TitleText, song.ArtistID, song.ArtistNameText, song.AlbumID, song.AlbumText,
                                Properties.Resources.External_URL + "/Album/" + song.ArtistNameText + "-" + song.AlbumText + "/" + song.TitleText + ".flac"));
                            Debug.WriteLine(1);
                        }
                    }
                    Program.musicPlayer.PlayInOrder();
                    if (songPlayButton.isPlaying)
                    {
                        songPlayButton.isPlaying = false;
                        Program.DownPlayButton.isPlaying = false;
                    }
                    songPlayButton.ToggleShape();
                    Program.DownPlayButton.ToggleShape();
                }
            }
            else
            {
                Program.musicPlayer.Stop();
                if (!songPlayButton.isPlaying)
                {
                    songPlayButton.isPlaying = true;
                    Program.DownPlayButton.isPlaying = true;
                }  
                songPlayButton.ToggleShape();
                Program.DownPlayButton.ToggleShape();
            }
            songPlayButton.ToggleShape();
            Program.DownPlayButton.ToggleShape();
        }

        public static float GetScreenScalingFactor()
        {
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                float dpiX = graphics.DpiX;
                // 标准 DPI 通常是 96，所以缩放比例是当前 DPI 与 96 的比值
                return dpiX / 96.0f;
            }
        }

        private void PictureBoxLove_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 鼠标悬停时使用白色，否则使用灰色
            Color heartColor = Color.White;
            if (type == "Artist")
            {
                heartColor = (pictureBoxLove.ClientRectangle.Contains(pictureBoxLove.PointToClient(Cursor.Position))) ? Color.White : Color.Gray;
                foreach (var artistInfo in UserAPI.favoriteResponse.Data.ArtistInfos)
                {
                    if (artistInfo.ID == ID)
                    {
                        heartColor = Color.Green;
                    }
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
                    path.AddBezier(x, y - size / 2, x - controlOffset, y - size, x - size, y - size / 2, x, y + size / 4);
                    path.AddBezier(x, y + size / 4, x + size, y - size / 2, x + controlOffset, y - size, x, y - size / 2);


                    // 绘制爱心形状
                    g.DrawPath(heartPen, path);
                }
            }
        }
    }


}
