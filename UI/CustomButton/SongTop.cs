using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.UI.Button
{
    using global::MusicBox.UI.CustomPictureBox;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Reflection;
    using System.Windows.Forms;

    public class SongTop : UserControl
    {
        private PictureBox pictureBox;
        private Label type;
        private Label name;
        private Label description;

        // 声明一个点击事件
        public event EventHandler ButtonClick;
        public SongTop()
        {
            // 创建并设置 PictureBox
            pictureBox = new PictureBox
            {
                Size = new Size((int)(Height * (1 / 2.0)), (int)(Height * (1 / 2.0))),
                Location = new Point((int)(Height * (1 / 10.0)), (int)(Height * (1 / 7.0))),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(pictureBox);

            // 创建并设置 Label
            type = new Label
            {
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point((int)(Height * (9 / 10.0)), (int)(Height * (1 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(type);

            // 创建并设置 Label
            name = new Label
            {
                Font = new Font("Microsoft YaHei UI", 50F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point((int)(Height * (9 / 10.0)), (int)(Height * (1 / 5.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(name);

            // 创建并设置 Label
            description = new Label
            {
                Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(Height, (int)(Height * (9 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(description);

            // 为用户控件开启双缓冲，减少闪烁
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this.SizeChanged += SizeChangedHandler;
        }

        // 重写绘制背景的方法
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            // 创建渐变画刷
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.White,
                                                                       Color.FromArgb(18, 18, 18),
                                                                       LinearGradientMode.Vertical))
            {
                // 填充背景
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            pictureBox.Size = new Size((int)(Height * (8 / 10.0)), (int)(Height * (8 / 10.0)));
            type.Location = new Point((int)(Height ), (int)(Height * (1 / 8.0)));
            name.Location = new Point((int)(Height * (9 / 10.0)), (int)(Height * (1 / 5.0)));
            description.Location = new Point((int)(Height ), (int)(Height * (15 / 20.0)));
        }

        // 公共属性设置图片
        public Image Image
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }
        public string TypeText
        {
            get => type.Text;
            set => type.Text = value;
        }

        public string NameText
        {
            get => name.Text;
            set => name.Text = value;
        }

        public string DescriptionText
        {
            get => description.Text;
            set => description.Text = value;
        }
    }

}
