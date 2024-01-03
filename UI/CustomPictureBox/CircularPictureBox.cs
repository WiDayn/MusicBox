using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.UI.CustomPictureBox
{
    public class CircularPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 使用 TextureBrush 绘制图片
            if (this.Image != null)
            {
                TextureBrush tb = new TextureBrush(this.Image);
                g.FillEllipse(tb, 0, 0, this.Width, this.Height);
            }

            // 绘制边界（可选）
            g.DrawEllipse(new Pen(Color.Black), 0, 0, this.Width - 1, this.Height - 1);
        }
    }
}
