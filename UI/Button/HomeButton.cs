using System;
using System.Drawing;
using System.Windows.Forms;

public class HomeButton : Button
{
    public HomeButton()
    {
        // 设置按钮样式为 Flat，边框大小为 0
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        // 确保按钮背景
        this.BackColor = Color.FromArgb(18, 18, 18);
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        PaintHome(pe);
    }

    public void ToggleShape()
    {
        this.Invalidate();
    }

    protected void PaintHome(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        // 创建图形对象并设置抗锯齿
        Graphics graphics = pe.Graphics;
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // 定义图标的外观颜色和尺寸
        int padding = 8;
        int size = Math.Min(Width, Height) - 2 * padding;
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
        using (Pen outlinePen = new Pen(Color.Gray, 3))
        {
            graphics.DrawPolygon(outlinePen, outlinePoints);
        }

        // 绘制房门
        RectangleF door = new RectangleF(
            (size + 2*padding - doorWidth) / 2,
            Height - padding - doorHeight,
            doorWidth,
            doorHeight);

        using (Pen doorPen = new Pen(Color.Gray, 3))
        {
            graphics.DrawRectangle(doorPen, door.X, door.Y, door.Width, door.Height);
        }

        // 绘制按钮文字
        string buttonText = "主页";
        SizeF textSize = graphics.MeasureString(buttonText, Font);
        Point textLocation = new Point(50, 8);
        TextRenderer.DrawText(graphics, buttonText, Font, textLocation, Color.Gray);
    }
}
