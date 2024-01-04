using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 绘制图片
            g.DrawImage(this.Image, 0, 0, this.Width, this.Height);

            // 创建遮罩区域
            using (Brush brush = new SolidBrush(BackColor))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    // 添加圆形外的区域
                    path.AddEllipse(0, 0, this.Width, this.Height);
                    Region region = new Region(new Rectangle(0, 0, this.Width, this.Height));
                    region.Exclude(path);

                    // 在圆形外的区域填充颜色
                    g.FillRegion(brush, region);
                }
            }
        }
    }
}
