using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class LyricsButton : Button
{
    private bool isMouseOver = false;

    public LyricsButton()
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
        PaintLyricsButton(pe);
    }
    protected void PaintLyricsButton(PaintEventArgs pe)
    {
        base.OnPaint(pe); // 调用基类的 OnPaint 方法来处理基本的绘制

        // 获取 Graphics 对象
        Graphics graphics = pe.Graphics;
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // 根据鼠标状态选择画笔颜色
        Color penColor = isMouseOver ? Color.White : Color.Gray;
        int penWidth = 2; // 定义画笔宽度
        using (Pen pen = new Pen(penColor, penWidth))
        {
            // 麦克风头部的宽度略大于手柄
            int micHeadWidth = 10;
            int micHandleWidthTop = 8;
            int micHandleWidthBottom = 5; // 手柄底部的宽度小于顶部

            // 将绘图原点移动到麦克风的中心
            graphics.TranslateTransform(this.Width / 2, 20);

            // 应用旋转变换
            graphics.RotateTransform(30);

            // 绘制麦克风的上半部分（麦克风头），坐标应相对于新的原点
            Rectangle micHeadRect = new Rectangle(-micHeadWidth / 2, -15, micHeadWidth, 10);
            graphics.DrawEllipse(pen, micHeadRect);

            // 创建一个 GraphicsPath 用于绘制手柄
            using (GraphicsPath path = new GraphicsPath())
            {
                // 手柄的顶部
                int handleTop = -7;
                int handleHeight = 15;
                path.AddLine(new Point(-micHandleWidthTop / 2, handleTop), new Point(-micHandleWidthBottom / 2, handleTop + handleHeight));
                path.AddLine(new Point(micHandleWidthBottom / 2, handleTop + handleHeight), new Point(micHandleWidthTop / 2, handleTop));

                // 绘制手柄
                graphics.DrawPath(pen, path);
            }

            // 重置图形变换
            graphics.ResetTransform();
        }
    }



}
