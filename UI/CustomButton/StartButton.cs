using System;
using System.Drawing;
using System.Windows.Forms;

public class PlayButton : Button
{
    public bool isPlaying = true; // 初始状态为开始

    public PlayButton()
    {
        // 设置按钮样式为 Flat，边框大小为 0
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        // 确保按钮背景是黑色的
        this.BackColor = Color.FromArgb(18, 18, 18);

        this.FlatAppearance.MouseDownBackColor = Color.FromArgb(18, 18, 18);
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        if (isPlaying)
        {
            PaintPlaying(pe);
        }
        else
        {
            PaintStop(pe);
        }
    }
    public void ToggleShape()
    {
        isPlaying = !isPlaying;
        this.Invalidate();
    }

    protected void PaintStop(PaintEventArgs pe)
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

    protected void PaintPlaying(PaintEventArgs pe)
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

        // 定义正三角形的大小，使其适当地适应圆形内部
        float triangleSideLength = (float)(diameter * 2 / (2 * Math.Sqrt(3))); // 侧长
        float triangleHeight = (float)(triangleSideLength * Math.Sqrt(3) / 2); // 高度

        // 计算三角形的中心点（重心）
        PointF centerPoint = new PointF(this.Width / 2, this.Height / 2);

        // 以中心点为基准计算三角形的三个顶点
        PointF[] trianglePoints = new PointF[3];
        trianglePoints[0] = new PointF(centerPoint.X - triangleSideLength / 2, centerPoint.Y + triangleHeight / 3);
        trianglePoints[1] = new PointF(centerPoint.X + triangleSideLength / 2, centerPoint.Y + triangleHeight / 3);
        trianglePoints[2] = new PointF(centerPoint.X, centerPoint.Y - (2 * triangleHeight / 3));

        // 为了横置三角形，我们绕中心点旋转三角形的顶点
        float angle = 90; // 旋转角度
        for (int i = 0; i < trianglePoints.Length; i++)
        {
            trianglePoints[i] = RotatePoint(trianglePoints[i], centerPoint, angle);
        }

        // 绘制三角形
        Brush triangleBrush = new SolidBrush(Color.Black);
        graphics.FillPolygon(triangleBrush, trianglePoints);
    }

    private PointF RotatePoint(PointF pointToRotate, PointF centerPoint, float angleInDegrees)
    {
        float angleInRadians = angleInDegrees * (float)(Math.PI / 180);
        float cosTheta = (float)Math.Cos(angleInRadians);
        float sinTheta = (float)Math.Sin(angleInRadians);
        return new PointF
        {
            X =
                cosTheta * (pointToRotate.X - centerPoint.X) -
                sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X,
            Y =
                sinTheta * (pointToRotate.X - centerPoint.X) +
                cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y
        };
    }
}
