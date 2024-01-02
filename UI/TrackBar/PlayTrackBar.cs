using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

public class PlayTrackBar : TrackBar
{
    private bool isDragging = false;
    // 声明新事件
    public event EventHandler ScrollChanged;
    public PlayTrackBar()
    {
        this.SetStyle(ControlStyles.UserPaint, true);
        this.MouseDown += CustomTrackBar_MouseDown;
        this.MouseMove += CustomTrackBar_MouseMove;
        this.MouseUp += CustomTrackBar_MouseUp;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // 调用基类的 OnPaint 方法
        base.OnPaint(e);

        Rectangle trackRectangle = ClientRectangle;

        Rectangle fullRectangle = new Rectangle(
            trackRectangle.X,
            trackRectangle.Y,
            (int)Size.Width,
            Size.Height);

        // 使用 GDI+ 绘制自定义外观
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(77, 77, 77))) // 进度条颜色
        {
            e.Graphics.FillRectangle(brush, fullRectangle);
        }

        Rectangle progressRectangle = new Rectangle(
            trackRectangle.X,
            trackRectangle.Y,
            (int)(Size.Width * ((double)Value / Maximum)),
            Size.Height);

        // 使用 GDI+ 绘制自定义外观
        using (SolidBrush brush = new SolidBrush(Color.White)) // 进度条颜色
        {
            e.Graphics.FillRectangle(brush, progressRectangle);
        }
        

        //// 绘制滑块
        //Rectangle thumbRect = new Rectangle(
        //    (int)(trackRectangle.Width * ((double)this.Value / this.Maximum)) - 8,
        //    trackRectangle.Y + trackRectangle.Height / 2 - 8,
        //    16, 16); // 可以调整滑块的大小

        //e.Graphics.FillRectangle(Brushes.Gray, thumbRect); // 滑块颜色
    }


    private void CustomTrackBar_MouseDown(object sender, MouseEventArgs e)
    {
        isDragging = true;
        UpdateValueFromMouse(e.X);
    }

    private void CustomTrackBar_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            UpdateValueFromMouse(e.X);
        }
    }

    private void CustomTrackBar_MouseUp(object sender, MouseEventArgs e)
    {
        isDragging = false;
        UpdateValueFromMouse(e.X);
    }

    private void UpdateValueFromMouse(int mouseX)
    {
        int newvalue = (int)(((double)mouseX / (double)this.Width) * (this.Maximum - this.Minimum));
        newvalue = Math.Max(this.Minimum, Math.Min(this.Maximum, newvalue));
        if (this.Value != newvalue)
        {
            this.Value = newvalue;
            this.OnScrollChanged(EventArgs.Empty);
        }
        this.Refresh();
    }

    // 事件触发器方法
    protected virtual void OnScrollChanged(EventArgs e)
    {
        ScrollChanged?.Invoke(this, e);
    }

    public void ToggleShape()
    {
        Invalidate();
    }
}