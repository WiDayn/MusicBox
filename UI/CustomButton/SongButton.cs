using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using MusicBox.UI.CustomPictureBox;

namespace MusicBox.UI.Button
{
    public class SongButton : UserControl
    {
        private Label labelIndex;
        private PictureBox pictureBox;
        private Label Title;
        private Label Description;
        private Label labelAlbum;
        private Label labelDuration;
        private bool MouseOn = false;

        public SongButton()
        {
            InitializeControls();
        }

        private void InitializeControls()
        {

            // 序号标签
            labelIndex = new Label
            {
                AutoSize = true,
                Location = new Point((int)(Height * (1 / 10.0)), (int)(Height * (1 / 7.0))),
                Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
            };
            this.Controls.Add(labelIndex);

            // 创建并设置 PictureBox
            pictureBox = new PictureBox
            {
                Size = new Size((int)(Height * (3 / 10.0)), (int)(Height * (3 / 10.0))),
                Location = new Point((int)(Height * (1 / 2.0)), (int)(Height * (1 / 20.0))),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(pictureBox);

            // 创建并设置 Title Label
            Title = new Label
            {
                Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point((int)(Height * (9 / 10.0)), (int)(Height * (1 / 20.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(Title);

            // 创建并设置 Description Label
            Description = new Label
            {
                Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                AutoSize = true,
                Location = new Point((int)(Height * (37 / 40.0)), (int)(Height * ( 1 / 4.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(Description);

            // 专辑标签
            labelAlbum = new Label
            {
                AutoSize = true,
                Location = new Point(Width * 2, (int)(Height * (1 / 7.0))),
                Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
            };
            this.Controls.Add(labelAlbum);

            // 时长标签
            labelDuration = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft YaHei UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                Location = new Point(Width * 3, (int)(Height * (1 / 7.0))),
            };
            this.Controls.Add(labelDuration);


            this.SizeChanged += SizeChangedHandler;

            this.MouseEnter += new EventHandler(RecentButton_MouseEnter);
            this.MouseLeave += new EventHandler(RecentButton_MouseLeave);
        }

        private void RecentButton_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标停留在TrackBar上时的逻辑
            MouseOn = true;
            BackColor = Color.FromArgb(BackColor.R + 8, BackColor.R + 8, BackColor.R + 8);
            ToggleShape();
        }

        // 当鼠标离开TrackBar时触发的方法
        private void RecentButton_MouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开TrackBar时的逻辑
            MouseOn = false;
            BackColor = Color.FromArgb(BackColor.R - 8, BackColor.R - 8, BackColor.R - 8);
            ToggleShape();
        }

        // 公共属性允许外部访问和设置控件的文本
        public string Index
        {
            get => labelIndex.Text;
            set => labelIndex.Text = value;
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

        public string Album
        {
            get => labelAlbum.Text;
            set => labelAlbum.Text = value;
        }

        public string Duration
        {
            get => labelDuration.Text;
            set => labelDuration.Text = value;
        }

        // 当鼠标点击时触发
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            // 修改背景颜色
            BackColor = Color.FromArgb(26, 26, 26);
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            labelAlbum.Location = new Point(Width / 2, (int)(Height * (5 / 14.0)));
            labelDuration.Location = new Point(Width * 8 / 9, (int)(Height * (5 / 14.0)));
        }

        public void ToggleShape()
        {
            Invalidate();
        }
    }
}
