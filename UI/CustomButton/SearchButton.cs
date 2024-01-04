using MusicBox.Core.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

public class SearchButton : Button
{
    private bool isMouseOver = false;

    public SearchButton()
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
        this.MouseEnter += SearchButton_MouseEnter;
        this.MouseLeave += SearchButton_MouseLeave;
        this.MouseDown += SearchButton_MouseDown;
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
    private void SearchButton_MouseEnter(object sender, EventArgs e)
    {
        isMouseOver = true;
        this.Invalidate();
    }

    private void SearchButton_MouseLeave(object sender, EventArgs e)
    {
        isMouseOver = false;
        this.Invalidate();
    }

    private void SearchButton_MouseDown(object sender, MouseEventArgs e)
    {
        SharedData.Flag = false;
        this.Invalidate();
    }


    protected override void OnPaint(PaintEventArgs pe)
    {
        PaintSearch(pe);
    }

    protected void PaintSearch(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        Graphics g = pe.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // 根据鼠标状态选择画笔颜色
        Color penColor = Color.Gray;
        if (isMouseOver)
        {
            penColor = Color.FromArgb(240, 255, 255);
        }
        if (!SharedData.Flag)
        {
            penColor = Color.White;
        }

        // 设置画笔
        using (Pen pen = new Pen(penColor, 3))
        {
            // 计算放大镜的圆圈部分
            int padding = (int)(10 / GetScreenScalingFactor());
            int size = Math.Min(Width, Height) - padding * 2;
            int radius = size / 2;
            Point center = new Point(padding + radius, padding + radius);
            g.DrawEllipse(pen, center.X - radius, center.Y - radius, size, size);

            // 计算并绘制放大镜的柄
            int handleLength = radius;
            Point handleStart = new Point(center.X + (int)(radius * 0.8), center.Y + (int)(radius * 0.8));
            Point handleEnd = new Point(handleStart.X + handleLength, handleStart.Y + handleLength);
            g.DrawLine(pen, handleStart, handleEnd);
        }

        // 绘制按钮文字
        string buttonText = "搜索";
        SizeF textSize = g.MeasureString(buttonText, Font);
        Point textLocation = new Point(50, 8);
        Color textColor = !SharedData.Flag ? Color.White : (isMouseOver ? Color.FromArgb(240, 255, 255) : Color.Gray);
        TextRenderer.DrawText(g, buttonText, Font, textLocation, textColor);
    }
}
