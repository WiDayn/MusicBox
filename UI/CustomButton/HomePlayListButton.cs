using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using MusicBox.Core.Dtos;
using MusicBox.Core.PlayBack.Player;
using MusicBox.UI.CustomPictureBox;

namespace MusicBox.UI.Button
{
    public class HomePlayListButton : UserControl
    {
        private PictureBox pictureBox;
        private Label title;
        private Label description;

        // 声明一个点击事件
        public event EventHandler ButtonClick;

        public HomePlayListButton()
        {
            // 设置控件的初始大小
            Size = new Size(300, 100);

            // 创建并设置 PictureBox
            pictureBox = new PictureBox
            {
                Size = new Size((int)(Width * (6 / 10.0)), (int)(Width * (6 / 10.0))),
                Location = new Point((int)(Width * (2 / 10.0)), (int)(Height * (1 / 20.0))),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(pictureBox);

            // 创建并设置 Title Label
            title = new Label
            {
                Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(0, (int)(Height * (6 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(title);

            // 创建并设置 Description Label
            description = new Label
            {
                Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                AutoSize = true,
                Location = new Point(0, (int)(Height * (6 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(description);


            this.SizeChanged += SizeChangedHandler;

            this.MouseEnter += new EventHandler(HomePlayListButton_MouseEnter);
            this.MouseLeave += new EventHandler(HomePlayListButton_MouseLeave);
            this.MouseDoubleClick += new MouseEventHandler(HomePlayListButton_DoubleClick);
        }

        private void HomePlayListButton_DoubleClick(object sender, EventArgs e)
        {
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            pictureBox.Location = new Point((int)(Width * (3 / 20.0)), (int)(Height * (1 / 40.0)));
            pictureBox.Size = new Size((int)(Width * (13 / 20.0)), (int)(Width * (13 / 20.0)));
            title.Location = new Point((int)(Width * (3 / 20.0)), (int)(Height * (7 / 10.0)));
            description.Location = new Point((int)(Width * (3 / 20.0)), (int)(Height * (8 / 10.0)));
        }

        private void HomePlayListButton_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标停留在TrackBar上时的逻辑
            BackColor = Color.FromArgb(BackColor.R + 8, BackColor.R + 8, BackColor.R + 8);
            ToggleShape();
        }

        // 当鼠标离开TrackBar时触发的方法
        private void HomePlayListButton_MouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开TrackBar时的逻辑
            BackColor = Color.FromArgb(BackColor.R - 8, BackColor.R - 8, BackColor.R - 8);
            ToggleShape();
        }

        // 公共属性设置图片
        public Image Image
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }

        public string TitleText
        {
            get => title.Text;
            set => title.Text = value;
        }

        public string DescriptionText
        {
            get => description.Text;
            set => description.Text = value;
        }

        public void ToggleShape()
        {
            Invalidate();
        }
    }
}
