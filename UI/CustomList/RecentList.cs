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
    public class RecentList : UserControl
    {
        private FlowLayoutPanel Panel;

        public RecentList()
        {
            AutoScroll = false;
            // 创建并设置内部的 FlowLayoutPanel
            Panel = new FlowLayoutPanel
            {
                AutoScroll = true, // 启用自动滚动
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
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

        public void Sort()
        {
            // 使用 LINQ 对按钮进行排序
            var sortedButtons = Panel.Controls.OfType<RecentButton>()
                                      .OrderBy(button => button.TitleText) // 这里以 Text 属性为例进行排序
                                      .ToList();

            // 清除 FlowLayoutPanel 中的所有控件
            Panel.Controls.Clear();

            // 将排序后的按钮重新添加到 FlowLayoutPanel
            foreach (var button in sortedButtons)
            {
                Panel.Controls.Add(button);
            }
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            foreach (RecentButton item in Panel.Controls)
            {
                item.Width = (int)(Width - (23 * GetScreenScalingFactor()));
            }
            Panel.Size = new Size(Width, Height);
        }


        // 方法：添加 RecentButton
        public void AddRecentButton(string imgPath, string titleText, string descriptionText)
        {
            var recentButton = new RecentButton
            {
                Width = (int)(Width - (23 * GetScreenScalingFactor())), // 减去滚动条的宽度
                Height = 120,
            };
            recentButton.Image = Image.FromFile(imgPath);
            recentButton.TitleText = titleText;
            recentButton.DescriptionText = descriptionText;
            Panel.Controls.Add(recentButton);
        }
    }
}
