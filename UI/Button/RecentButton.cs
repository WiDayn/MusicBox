﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.UI.Button
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class RecentButton : UserControl
    {
        private PictureBox pictureBox;
        private Label Title;
        private Label Description;

        public RecentButton()
        {
            // 设置控件的初始大小
            Size = new Size(300, 100);
            // 创建并设置 PictureBox
            pictureBox = new PictureBox
            {
                Size = new Size((int)(Height * (6 / 10.0)), (int)(Height * (6 / 10.0))),
                Location = new Point((int)(Height * (1 / 10.0)), (int)(Height * (2 / 10.0))),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(pictureBox);

            // 创建并设置 Label
            Title = new Label
            {
                Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point((int)(Height * (10.5 / 10.0)), (int)(Height * (3 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(Title);

            // 创建并设置 Label
            Description = new Label
            {
                Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                AutoSize = true,
                Location = new Point((int)(Height * (11 / 10.0)), (int)(Height * (6 / 10.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(Description);

            this.SizeChanged += SizeChangedHandler;
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            pictureBox.Size = new Size((int)(Height * (6 / 10.0)), (int)(Height * (6 / 10.0)));
        }

        // 公共属性设置图片
        public Image Image
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }

        public string TitleText
        {
            get => Title.Text;
            set => Title.Text = value;
        }

        public string DescriptionText
        {
            get => Description.Text;
            set => Description.Text = value;
        }
    }

}
