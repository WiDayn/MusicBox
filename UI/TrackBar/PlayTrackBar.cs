using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

public class PlayTrackBar : TrackBar
{
    private bool isDragging = false;
    private bool MouseOn = false;
    private const int WM_MOUSEWHEEL = 0x020A;

    public PlayTrackBar()
    {
        this.SetStyle(ControlStyles.UserPaint, true);
        this.MouseDown += CustomTrackBar_MouseDown;
        this.MouseMove += CustomTrackBar_MouseMove;
        this.MouseUp += CustomTrackBar_MouseUp;
        this.MouseEnter += new EventHandler(PlayTrackBar_MouseEnter);
        this.MouseLeave += new EventHandler(PlayTrackBar_MouseLeave);
    }

    protected override void WndProc(ref Message m)
    {
        // 如果消息是鼠标滚轮消息，则忽略
        if (m.Msg == WM_MOUSEWHEEL)
        {
            return;
        }

        // 否则，正常处理其他消息
        base.WndProc(ref m);
    }

    private void PlayTrackBar_MouseEnter(object sender, EventArgs e)
    {
        // 鼠标停留在TrackBar上时的逻辑
        MouseOn = true;
        ToggleShape();
    }

    // 当鼠标离开TrackBar时触发的方法
    private void PlayTrackBar_MouseLeave(object sender, EventArgs e)
    {
        // 鼠标离开TrackBar时的逻辑
        MouseOn = false;
        ToggleShape();
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        // 这里不调用基类的 OnMouseWheel 方法，以禁用滚轮功能
        // base.OnMouseWheel(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // 调用基类的 OnPaint 方法
        base.OnPaint(e);

        Rectangle trackRectangle = ClientRectangle;

        Rectangle fullRectangle = new Rectangle(
            trackRectangle.X + 3,
            trackRectangle.Y + 3,
            Size.Width,
           4);

        // 使用 GDI+ 绘制自定义外观
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(77, 77, 77))) // 进度条颜色
        {
            e.Graphics.FillRectangle(brush, fullRectangle);
        }

        Rectangle progressRectangle = new Rectangle(
            trackRectangle.X + 3,
            trackRectangle.Y + 3,
            (int)(Size.Width * ((double)Value / Maximum)),
            4);

        // 使用 GDI+ 绘制自定义外观
        using (SolidBrush brush = new SolidBrush(MouseOn ? Color.FromArgb(29, 185, 84) : Color.White)) // 进度条颜色
        {
            e.Graphics.FillRectangle(brush, progressRectangle);
        }


        if (MouseOn)
        {
            // 绘制滑块
            Brush thumbBrush = new SolidBrush(Color.White);
            Rectangle thumbRect = new Rectangle(
                (int)((Size.Width - 10) * ((double)Value / Maximum)), 0,
                10, 10); // 可以调整滑块的大小

            e.Graphics.FillEllipse(thumbBrush, thumbRect); // 滑块颜色
        }
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
        }
        this.Refresh();
    }

    public void ToggleShape()
    {
        Invalidate();
    }
}