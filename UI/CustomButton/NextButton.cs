using System;
using System.Drawing;
using System.Windows.Forms;

public class NextButton : Button
{
    private bool isMouseOver = false;

    public NextButton()
    {
        // 设置按钮样式为 Flat，边框大小为 0
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        // 确保按钮背景是黑色的
        this.BackColor = Color.Black;
        this.FlatAppearance.MouseDownBackColor = Color.Black;

        // 添加鼠标事件处理程序
        this.MouseEnter += NextButton_MouseEnter;
        this.MouseLeave += NextButton_MouseLeave;
    }

    private void NextButton_MouseEnter(object sender, EventArgs e)
    {
        isMouseOver = true;
        this.Invalidate();
    }

    private void NextButton_MouseLeave(object sender, EventArgs e)
    {
        isMouseOver = false;
        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        PaintNext(pe);
    }

    protected void PaintNext(PaintEventArgs pe)
    {
        base.OnPaint(pe); // 调用基类的 OnPaint 方法来处理基本的绘制

        // 获取 Graphics 对象
        Graphics graphics = pe.Graphics;
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // 根据鼠标状态选择画笔颜色
        Color penColor = isMouseOver ? Color.White : Color.Gray;

        // 设置画笔
        using (Pen pen = new Pen(penColor, 3))
        {
            // 定义白色圆形背景
            int diameter = Math.Min(this.Width, this.Height) - 2; // 减去 2 以保留边缘

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
            Brush triangleBrush = new SolidBrush(penColor);
            graphics.FillPolygon(triangleBrush, trianglePoints);

            // 计算两个矩形的宽度和高度
            int rectWidth = this.Width / 6;
            int rectHeight = this.Height / 2;

            float rectX = centerPoint.X + triangleSideLength / 2;
            float rectY = centerPoint.Y - rectHeight / 2;

            // 定义矩形
            Brush rectBrush = new SolidBrush(penColor);
            Rectangle Rect = new Rectangle((int)rectX, (int)rectY, rectWidth, rectHeight);

            // 绘制矩形
            graphics.FillRectangle(rectBrush, Rect);
        }
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
