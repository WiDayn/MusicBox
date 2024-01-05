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
    public class HomePlayList : UserControl
    {
        public FlowLayoutPanel AlbumPanel;

        public HomePlayList()
        {
            AutoScroll = false;
            // 创建并设置内部的 FlowLayoutPanel
            AlbumPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight, // 从左到右排列
                WrapContents = true, // 允许内容折行
            };
            this.Controls.Add(AlbumPanel);

            AlbumPanel.Dock = DockStyle.Fill;
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
    }
}
