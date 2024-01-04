using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusicBox.UI.Button
{
    public class SongTitle : UserControl
    {
        private Label labelIndex;
        private Label Title;
        private Label labelAlbum;
        private PictureBox pictureBoxDuration;

        // 定义默认的前景颜色
        private readonly Color defaultForeColor = Color.FromArgb(167, 167, 167);
        // 定义悬停时的前景颜色
        private readonly Color hoverForeColor = Color.White;

        public SongTitle()
        {
            InitializeControls();
        }

        private void InitializeControls()
        {
            // 序号标签
            labelIndex = CreateLabel("#", (int)(Height * (1 / 10.0)), (int)(Height * (1 / 7.0)));
            this.Controls.Add(labelIndex);

            // 创建并设置 Title Label
            Title = CreateLabel("标题", (int)(Height * (1 / 2.0)), (int)(Height * (1 / 7.0)));
            this.Controls.Add(Title);

            // 专辑标签
            labelAlbum = CreateLabel("专辑", Width / 2, (int)(Height * (1 / 7.0)));
            this.Controls.Add(labelAlbum);

            // 创建并设置时长图标 PictureBox
            pictureBoxDuration = new PictureBox
            {
                Size = new Size(19, 19), // 或者任何适合的大小
                Location = new Point(Width * 3, (int)(Height * (1 / 7.0))), // 调整位置以适合您的布局
                BackColor = Color.Transparent
            };
            pictureBoxDuration.Paint += PictureBoxDuration_Paint;
            // 添加鼠标事件处理器
            pictureBoxDuration.MouseEnter += (sender, e) => { pictureBoxDuration.Invalidate(); };
            pictureBoxDuration.MouseLeave += (sender, e) => { pictureBoxDuration.Invalidate(); };

            this.Controls.Add(pictureBoxDuration);

            this.SizeChanged += SizeChangedHandler;

            // 添加分割线
            Panel dividerLine = new Panel
            {
                Size = new Size(this.Width - 20, 1), // 分割线长度为控件宽度减去两边的空隙
                Location = new Point(10, this.Height -20), // 分割线位于控件底部，左右各留出10像素的空隙
                BackColor = defaultForeColor // 分割线颜色
            };
            this.Controls.Add(dividerLine);

            // 确保在控件大小改变时更新分割线的宽度和位置
            this.SizeChanged += (sender, e) =>
            {
                dividerLine.Width = this.Width - 20; // 更新宽度
                dividerLine.Location = new Point(10, this.Height - 20); // 更新位置
            };
        }

        private void PictureBoxDuration_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 用于时钟图标的颜色和笔刷
            Color clockColor = (pictureBoxDuration.ClientRectangle.Contains(pictureBoxDuration.PointToClient(Cursor.Position))) ? hoverForeColor : defaultForeColor;
            using (Pen clockPen = new Pen(clockColor, 2))
            {

                // 计算中心点
                int centerX = pictureBoxDuration.Width / 2;
                int centerY = pictureBoxDuration.Height / 2;
                int radius = (int)(Math.Min(centerX, centerY) - clockPen.Width); // 半径为宽或高的最小值减去笔宽

                // 绘制时钟外圈
                g.DrawEllipse(clockPen, centerX - radius, centerY - radius, radius * 2, radius * 2);

                // 计算时针和分针的位置
                // 这里简化了计算，假设时钟指向10点10分的方向
                // 时针约为半径的一半长，分针约为半径的四分之三长
                Point hourHandEnd = new Point(centerX - radius / 2, centerY);
                Point minuteHandEnd = new Point(centerX, centerY - (radius * 3 / 4));

                // 绘制时针
                g.DrawLine(clockPen, centerX, centerY, hourHandEnd.X, hourHandEnd.Y);
                // 绘制分针
                g.DrawLine(clockPen, centerX, centerY, minuteHandEnd.X, minuteHandEnd.Y);
            }
        }

        private Label CreateLabel(string text, int x, int y)
        {
            Label label = new Label
            {
                AutoSize = true,
                Location = new Point(x, y),
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = defaultForeColor,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                Text = text
            };

            // 添加鼠标事件处理器
            label.MouseEnter += (sender, e) => label.ForeColor = hoverForeColor;
            label.MouseLeave += (sender, e) => label.ForeColor = defaultForeColor;

            return label;
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            labelAlbum.Location = new Point(Width / 2, labelAlbum.Location.Y);
            pictureBoxDuration.Location = new Point(Width * 7 / 8, pictureBoxDuration.Location.Y);
        }

        public void ToggleShape()
        {
            Invalidate();
        }
    }
}
