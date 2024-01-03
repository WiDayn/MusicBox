using System;
using System.Drawing;
using System.Windows.Forms;

public class SearchButton : Button
{
    public SearchButton()
    {
        // 设置按钮样式为 Flat，边框大小为 0
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        // 确保按钮背景
        this.BackColor = Color.FromArgb(18, 18, 18);
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        PaintSearch(pe);
    }

    public void ToggleShape()
    {
        this.Invalidate();
    }
    protected void PaintSearch(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        Graphics g = pe.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // 设置画笔
        Pen pen = new Pen(Color.Gray, 3); // 白色画笔，线宽为3

        // 计算放大镜的圆圈部分
        int padding = 10;
        int size = Math.Min(Width, Height) - padding * 2;
        int radius = size / 2;
        Point center = new Point(padding + radius, padding + radius);
        g.DrawEllipse(pen, center.X - radius, center.Y - radius, size, size);

        // 计算并绘制放大镜的柄
        int handleLength = radius ;
        Point handleStart = new Point(center.X + (int)(radius * 0.8), center.Y + (int)(radius * 0.8));
        Point handleEnd = new Point(handleStart.X + handleLength, handleStart.Y + handleLength);
        g.DrawLine(pen, handleStart, handleEnd);

        // 绘制按钮文字
        string buttonText = "搜索";
        SizeF textSize = g.MeasureString(buttonText, Font);
        Point textLocation = new Point(50,8);
        TextRenderer.DrawText(g, buttonText, Font, textLocation, Color.Gray);
    }
}
