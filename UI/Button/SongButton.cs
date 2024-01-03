using System;
using System.Drawing;
using System.Windows.Forms;

public class SongButton : Button
{
    public SongButton()
    {
        // 设置按钮样式为 Flat，边框大小为 0
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        // 确保按钮背景
        this.BackColor = Color.FromArgb(18, 18, 18);
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        PaintSong(pe);
    }

    public void ToggleShape()
    {
        this.Invalidate();
    }

    protected void PaintSong(PaintEventArgs pe)
    {

    }
}
