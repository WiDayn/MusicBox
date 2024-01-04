using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.UI.CustomButton
{
    public class RoundedPanelButton : Panel
    {
        public Label ButtonLabel { get; private set; }

        // 声明一个点击事件
        public event EventHandler ButtonClick;

        public RoundedPanelButton()
        {
            // 初始化Label
            this.ButtonLabel = new Label
            {
                Text = "登录",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font("Microsoft YaHei", 10F, FontStyle.Bold)
            };

            // 设置Panel的属性
            this.BackColor = Color.FromArgb(1, 183, 70); // 按钮背景颜色
            this.Size = new Size(100, 40); // 根据需要调整大小
            this.Controls.Add(ButtonLabel);

            // 设置圆角区域
            UpdateRegion();

            ButtonLabel.MouseEnter += new EventHandler(RoundedPanelBox_MouseEnter);
            ButtonLabel.MouseLeave += new EventHandler(RoundedPanelBox_MouseLeave);
            ButtonLabel.MouseClick += new MouseEventHandler(ButtonLabel_MouseClick);
        }
        private void ButtonLabel_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine(1);
            OnButtonClick();
        }

        // 触发ButtonClick事件的方法
        protected virtual void OnButtonClick()
        {
            ButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void RoundedPanelBox_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(BackColor.R + 30, BackColor.G + 30, BackColor.B + 30);
            ToggleShape();
        }

        private void RoundedPanelBox_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(BackColor.R - 30, BackColor.G - 30, BackColor.B - 30);
            ToggleShape();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            if (this.Width > 0 && this.Height > 0)
            {
                this.Region = new Region(GetRoundedRectPath(new Rectangle(0, 0, this.Width, this.Height), 20));
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();
            return path;
        }
        public void ToggleShape()
        {
            Invalidate();
        }
    }
}
