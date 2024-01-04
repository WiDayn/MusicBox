using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.UI.CustomTextBox
{
    public class RoundedTextBox : UserControl
    {
        private TextBox textBox;
        private int borderRadius = 2;
        private int borderWidth = 10;
        private Color borderColor = Color.FromArgb(114, 114, 114);

        public RoundedTextBox()
        {
            textBox = new TextBox();
            this.Padding = new Padding(borderWidth); // 确保边框可见
            textBox.BorderStyle = BorderStyle.None;
            textBox.Dock = DockStyle.Fill;
            textBox.Margin = new Padding(borderRadius); // 确保文本与边框有一定间距

            this.Size = new Size(Width, 29); // 根据需要调整大小
            this.BackColor = Color.Black;
            this.Controls.Add(textBox);

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            textBox.BackColor = Color.Black;
            textBox.ForeColor = Color.White;

            // 更新区域以使得 UserControl 的背景可见
            UpdateRegion();
            textBox.MouseEnter += new EventHandler(RoundedTextBox_MouseEnter);
            textBox.MouseLeave += new EventHandler(RoundedTextBox_MouseLeave);
        }

        private void RoundedTextBox_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标停留在TrackBar上时的逻辑
            borderColor = Color.FromArgb(255, 255, 255);
            ToggleShape();
        }

        // 当鼠标离开TrackBar时触发的方法
        private void RoundedTextBox_MouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开TrackBar时的逻辑
            borderColor = Color.FromArgb(114, 114, 114);
            ToggleShape();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 绘制边框
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                using (GraphicsPath path = GetRoundedRectPath(this.ClientRectangle, borderRadius))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private void UpdateRegion()
        {
            if (this.Width > 0 && this.Height > 0)
            {
                this.Region = new Region(GetRoundedRectPath(this.ClientRectangle, borderRadius));
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        // 添加公共属性来访问内部 TextBox 的属性
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public void ToggleShape()
        {
            Invalidate();
        }
    }
}
