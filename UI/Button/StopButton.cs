using System;
using System.Drawing;
using System.Windows.Forms;

public class StopButton : Button
{
    public StopButton()
    {
        // 设置按钮样式为 Flat，边框大小为 0
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        // 确保按钮背景是黑色的
        this.BackColor = Color.Black;
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe); // 调用基类的 OnPaint 方法来处理基本的绘制

        // 获取 Graphics 对象
        Graphics graphics = pe.Graphics;
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // 定义白色圆形背景
        Brush backgroundBrush = new SolidBrush(Color.White);
        int diameter = Math.Min(this.Width, this.Height) - 2; // 减去 2 以保留边缘
        Rectangle backgroundRectangle = new Rectangle((this.Width - diameter) / 2, (this.Height - diameter) / 2, diameter, diameter);
        graphics.FillEllipse(backgroundBrush, backgroundRectangle);

        // 计算两个矩形的宽度和高度
        int rectWidth = this.Width / 6;
        int rectHeight = this.Height / 2;

        // 计算两个矩形之间的空间以及它们相对于按钮中心的位置
        int space = rectWidth / 2;
        int totalRectWidth = 2 * rectWidth + space;
        int leftRectX = (this.Width - totalRectWidth) / 2;
        int rectY = (this.Height - rectHeight) / 2;

        // 定义两个黑色矩形
        Brush rectBrush = new SolidBrush(Color.Black);
        Rectangle leftRect = new Rectangle(leftRectX, rectY, rectWidth, rectHeight);
        Rectangle rightRect = new Rectangle(leftRectX + rectWidth + space, rectY, rectWidth, rectHeight);

        // 绘制两个黑色矩形
        graphics.FillRectangle(rectBrush, leftRect);
        graphics.FillRectangle(rectBrush, rightRect);
    }
}
