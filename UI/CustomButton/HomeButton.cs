using System;
using System.Drawing;
using System.Windows.Forms;

public class HomeButton : Button
{
    private bool isMouseOn = false;
    private bool isMouseDown = false;

    public HomeButton()
    {
        // 设置按钮样式为 Flat，边框大小为 0
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        // 确保按钮背景
        this.BackColor = Color.FromArgb(18, 18, 18);
        this.FlatAppearance.MouseDownBackColor = Color.FromArgb(18, 18, 18);
        // 设置按钮在鼠标悬浮时的背景色
        this.FlatAppearance.MouseOverBackColor = Color.FromArgb(18, 18, 18);
        // 添加鼠标事件处理程序
        this.MouseEnter += HomeButton_MouseEnter;
        this.MouseLeave += HomeButton_MouseLeave;
        this.MouseDown += HomeButton_MouseDown;
        this.MouseUp += HomeButton_MouseUp;
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
    private void HomeButton_MouseEnter(object sender, EventArgs e)
    {
        isMouseOn = true;
        isMouseDown = false;
        this.Invalidate();
    }

    private void HomeButton_MouseLeave(object sender, EventArgs e)
    {
        isMouseOn = false;
        isMouseDown = false;
        this.Invalidate();
    }

    private void HomeButton_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isMouseDown = true;
            this.Invalidate();
        }
    }

    private void HomeButton_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isMouseDown = false;
            this.Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        PaintHome(pe);
    }

    protected void PaintHome(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        // 创建图形对象并设置抗锯齿
        Graphics graphics = pe.Graphics;
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // 根据鼠标状态选择画笔颜色
        Color penColor = Color.Gray;
        if (isMouseOn)
        {
            penColor = Color.White;
        }
        if (isMouseDown)
        {
            penColor = Color.Blue;
        }

        // 设置画笔
        using (Pen outlinePen = new Pen(penColor, 3))
        {
            // 定义图标的外观颜色和尺寸
            int padding =  (int)(8 / GetScreenScalingFactor());
            int size = Math.Min(Width, Height) - padding * 2;
            float doorWidth = size / 4f;
            float doorHeight = size / 2f;

            // 定义房屋的外部轮廓点
            Point[] outlinePoints = new Point[]
            {
                // 底部左侧
                new Point(padding, Height - padding), 
                // 顶部左侧
                new Point(padding, padding + (Height - padding * 3) / 2), 
                // 屋顶顶点
                new Point(size/2 + padding, padding), 
                // 顶部右侧
                new Point(size+padding, padding + (Height - padding * 3) / 2),
                // 底部右侧
                new Point(size+padding, Height - padding)
            };

            // 绘制房屋外部轮廓
            graphics.DrawPolygon(outlinePen, outlinePoints);

            // 绘制房门
            RectangleF door = new RectangleF(
                (size + 2 * padding - doorWidth) / 2,
                Height - padding - doorHeight,
                doorWidth,
                doorHeight);

            using (Pen doorPen = new Pen(penColor, 3))
            {
                graphics.DrawRectangle(doorPen, door.X, door.Y, door.Width, door.Height);
            }

            // 绘制按钮文字
            string buttonText = "主页";
            SizeF textSize = graphics.MeasureString(buttonText, Font);
            Point textLocation = new Point(50, 8);
            Color textColor = isMouseDown ? Color.Blue : (isMouseOn ? Color.White : Color.Gray);
            TextRenderer.DrawText(graphics, buttonText, Font, textLocation, textColor);
        }
    }
}
