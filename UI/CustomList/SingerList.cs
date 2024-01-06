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
        public Panel TopPanel;
        public FlowLayoutPanel SongPanel;
        public FlowLayoutPanel AlbumPanel;
        public SingerList()
        {
            Width = 8000;
            AutoScroll = true; // 启用自动滚动
            FlowDirection = FlowDirection.TopDown;

            // 创建并设置内部的 FlowLayoutPanel
            TopPanel = new Panel{
                Dock = DockStyle.Fill,
            };
            this.Controls.Add(TopPanel);

            var songtext = new Label
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 20,
                Text = "热门",
                Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
            };
            this.Controls.Add(songtext);

            // 创建并设置内部的 FlowLayoutPanel
            SongPanel = new FlowLayoutPanel
            {
                AutoScroll = false, // 启用自动滚动
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Dock = DockStyle.Fill,
            };
            this.Controls.Add(SongPanel);

            var albumtext = new Label
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 20,
                Text = "唱片目录",
                Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
            };
            this.Controls.Add(albumtext);

            // 创建并设置内部的 FlowLayoutPanel
            AlbumPanel = new FlowLayoutPanel
            {
                AutoScroll = false, // 启用自动滚动
                FlowDirection = FlowDirection.LeftToRight, // 从左到右排列
                WrapContents = true, // 允许内容折行
            };
            this.Controls.Add(AlbumPanel);
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
        public async void SetSongTopFromIMG(string imgPath, string typeText, string nameText, string descriptionText)
        {
            var songTop = new SongTop
            {
                Width = Width, // 减去滚动条的宽度
                Height = 120,
                Dock = DockStyle.Fill,
            };
            songTop.Image = Image.FromFile(imgPath);

            songTop.TypeText = typeText;
            songTop.NameText = nameText;
            songTop.DescriptionText = descriptionText;
            TopPanel.Controls.Add(songTop);
        }

        public void AddTrackData(string index, string imgPath, string titleText, string artistNameText, string album, string duration)
        {
            var musicTrackControl = new SongButton
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 60,
            };
            musicTrackControl.Index = index;
            musicTrackControl.TitleText = titleText;
            musicTrackControl.ArtistNameText = artistNameText;
            musicTrackControl.Image = Image.FromFile(imgPath);
            musicTrackControl.AlbumText = album;
            musicTrackControl.Duration = duration;
            SongPanel.Controls.Add(musicTrackControl);
        }

        // 方法：添加 HomePlayListButton
        public void AddHomePlayListButton(string imgPath, string titleText, string descriptionText)
        {
            var homePlayListButton = new HomePlayListButton
            {
                Width = (int)(200 / GetScreenScalingFactor()), // 适应每行四个按钮的宽度
                Height = (int)(250 / GetScreenScalingFactor()),
            };
            homePlayListButton.Image = Image.FromFile(imgPath);
            homePlayListButton.TitleText = titleText;
            homePlayListButton.DescriptionText = descriptionText;
            AlbumPanel.Controls.Add(homePlayListButton);
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
