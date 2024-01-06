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
using static MusicBox.Core.Dtos.Album;

namespace MusicBox.UI.List
{
    public class RecentList : UserControl
    {
        public FlowLayoutPanel Panel;

        public RecentList()
        {
            AutoScroll = false;
            // 创建并设置内部的 FlowLayoutPanel
            Panel = new FlowLayoutPanel
            {
                AutoScroll = true, // 启用自动滚动
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Dock = DockStyle.Fill,
            };
            Panel.AutoScroll = true;
            this.Controls.Add(Panel);

            this.SizeChanged += SizeChangedHandler;
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


        private void SizeChangedHandler(object sender, EventArgs e)
        {
            foreach (var item in Panel.Controls)
            {
                if(item.GetType() == typeof(RecentButton))
                {
                    ((RecentButton)item).Width = (int)(Width - (23 * GetScreenScalingFactor()));
                } else
                {
                    ((SongButton)item).Width = (int)(Width - (23 * GetScreenScalingFactor()));
                }
                
            }
            Panel.Size = new Size(Width, Height);
        }


        // 方法：添加 RecentButton
        public async void AddRecentButtonFromAblumID(int albumID)
        {
            var recentButton = new RecentButton("Album")
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 120,
                ID = albumID,
            };
            Panel.Controls.Add(recentButton);
        }

        public void AddRecentButtonFromArtistID(int artistID)
        {
            var recentButton = new RecentButton("Artist")
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 120,
                ID = artistID,
            };
            Panel.Controls.Add(recentButton);
        }

        public void AddRecentButtonFromPlayListID(int playListID)
        {
            var recentButton = new RecentButton("PlayList")
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 120,
                ID = playListID,
            };
            Panel.Controls.Add(recentButton);
        }

        public void AddRecentButtonFromIMG(Image image, string type, string titleText, string descriptionText)
        {
            Debug.WriteLine(Width);
            var recentButton = new RecentButton(type)
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 120,
            };
            recentButton.Image = image;
            recentButton.TitleText = titleText;
            recentButton.DescriptionText = descriptionText;
            Panel.Controls.Add(recentButton);
        }

        // 公共方法用于设置音乐轨道项的数据
        public async void AddTrackData(string index, bool isHTTP, string imgPath, string titleText, string artistNameText, string album,string duration)
        {
            var musicTrackControl = new SongButton
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 60,
            };
            musicTrackControl.Index = index;
            musicTrackControl.TitleText = titleText;
            musicTrackControl.ArtistNameText = artistNameText;
            if (imgPath.StartsWith("http"))
            {
                musicTrackControl.Image = await ImgAPI.LoadImageFromUrlAsync(imgPath);
            }
            else
            {
                musicTrackControl.Image = Image.FromFile(imgPath);
            }
            musicTrackControl.AlbumText = album;
            musicTrackControl.Duration = duration;
            Panel.Controls.Add(musicTrackControl);
        }
    }
}
