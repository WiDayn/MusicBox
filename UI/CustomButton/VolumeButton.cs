using System;
using System.Drawing;
using System.Windows.Forms;

public class VolumeButton : Button
{
    private bool isMouseOver = false;

    public VolumeButton()
    {
        // 设置按钮样式为 Flat，边框大小为 0
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        // 确保按钮背景是黑色的
        this.BackColor = Color.Black;
        this.FlatAppearance.MouseDownBackColor = Color.Black;

        // 添加鼠标事件处理程序
        this.MouseEnter += VolumeButton_MouseEnter;
        this.MouseLeave += VolumeButton_MouseLeave;
    }

    private void VolumeButton_MouseEnter(object sender, EventArgs e)
    {
        isMouseOver = true;
        this.Invalidate();
    }

    private void VolumeButton_MouseLeave(object sender, EventArgs e)
    {
        isMouseOver = false;
        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        PaintVolumeButton(pe);
    }

    protected void PaintVolumeButton(PaintEventArgs pe)
    {
        base.OnPaint(pe); // 调用基类的 OnPaint 方法来处理基本的绘制

        // 获取 Graphics 对象
        Graphics graphics = pe.Graphics;
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // 根据鼠标状态选择画笔颜色
        Color penColor = isMouseOver ? Color.White : Color.Gray;
        using (Pen pen = new Pen(penColor, 2)) // 设置画笔颜色和宽度
        {
            // 画一个扬声器
            Point[] speakerPoints = {
            new Point(10, 10),
            new Point(20, 5),
            new Point(20, 25),
            new Point(10, 20)
        };
            graphics.FillPolygon(new SolidBrush(penColor), speakerPoints);

            // 画几个音量条
            graphics.DrawArc(pen, 15, 5, 10, 20, 60, -120);

        }
    }

}
