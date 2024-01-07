using MusicBox.API;
using MusicBox.Core.Entity;
using MusicBox.UI.Button;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicBox.UI.List
{
    public class SingerList : FlowLayoutPanel
    {
        public SongTopPanel TopPanel;
        public RecentList SongPanel = new();
        public HomePlayList AlbumPanel;
        public SingerList()
        {
            AutoScroll = true; // 启用自动滚动
            FlowDirection = FlowDirection.TopDown;
            WrapContents = false;
            BackColor = Color.FromArgb(18, 18, 18);
            // 创建并设置内部的 FlowLayoutPanel
            TopPanel = new SongTopPanel {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 300,
            };
            this.Controls.Add(TopPanel);

            var songtext = new Label
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 30,
                Text = "热门",
                Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
            };
            this.Controls.Add(songtext);

            // 创建并设置内部的 FlowLayoutPanel
            SongPanel = new RecentList
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())),
                Height = 600,
            };
            this.Controls.Add(SongPanel);

            var albumtext = new Label
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 30,
                Text = "唱片目录",
                Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
            };
            this.Controls.Add(albumtext);

            // 创建并设置内部的 FlowLayoutPanel
            AlbumPanel = new HomePlayList
            {
                AutoScroll = false,
                Width = (int)(Width - (23 * GetScreenScalingFactor())),
            };
            this.Controls.Add(AlbumPanel);
            Layout += (sender, e) => {
                TopPanel.Width = (int)(Width - (23 * GetScreenScalingFactor()));
                songtext.Width = (int)(Width - (23 * GetScreenScalingFactor()));
                SongPanel.Width = (int)(Width - (23 * GetScreenScalingFactor()));
                albumtext.Width = (int)(Width - (23 * GetScreenScalingFactor()));
                AlbumPanel.Width = (int)(Width - (23 * GetScreenScalingFactor()));
            };

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
        public void SetSongTop(string imgPath, string typeText, string nameText, string descriptionText)
        {
            TopPanel.SetSongTop(imgPath, typeText, nameText, descriptionText);
        }

        public void AddTrackData(string index, string imgPath, int songID, string titleText, string artistNameText, string album, string duration)
        {
            SongPanel.AddTrackData(index, false, imgPath, songID, titleText, artistNameText, album, duration);
        }

        // 方法：添加 HomePlayListButton
        public void AddHomePlayListButton(string imgPath, string titleText, string descriptionText)
        {
            AlbumPanel.AddHomePlayListButton(imgPath, titleText, descriptionText);
        }

        //公共方法用于设置音乐轨道项的数据
        //public async void AddTrackData(string index, bool isHTTP, string imgPath, string titleText, string artistNameText, string album, string duration)
        //{
        //    var musicTrackControl = new SongButton
        //    {
        //        Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
        //        Height = 60,
        //    };
        //    musicTrackControl.Index = index;
        //    musicTrackControl.TitleText = titleText;
        //    musicTrackControl.ArtistNameText = artistNameText;
        //    if (isHTTP)
        //    {
        //        musicTrackControl.Image = await ImgAPI.LoadImageFromUrlAsync(imgPath);
        //    }
        //    else
        //    {
        //        musicTrackControl.Image = Image.FromFile(imgPath);
        //    }
        //    musicTrackControl.AlbumText = album;
        //    musicTrackControl.Duration = duration;
        //    Panel.Controls.Add(musicTrackControl);
        //}
    }
}
