using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using MusicBox.Core.PlayBack.Player;
using MusicBox.UI.CustomPictureBox;

namespace MusicBox.UI.Button
{
    public class SongButton : UserControl
    {
        private int SongID { get; set; }
        private int ArtistID { get; set; }
        private int AlbumID { get; set; }
        private Label labelIndex;
        private PictureBox pictureBox;
        private Label Title;
        private Label ArtistName;
        private Label LabelAlbum;
        private Label LabelDuration;
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
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
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
            ArtistName = new Label
            {
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                AutoSize = true,
                Location = new Point((int)(Height * (9 / 10.0)), (int)(Height * ( 1 / 5.0))),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
            };
            this.Controls.Add(ArtistName);

            // 专辑标签
            LabelAlbum = new Label
            {
                AutoSize = true,
                Location = new Point(Width * 2, (int)(Height * (1 / 7.0))),
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
            };
            this.Controls.Add(LabelAlbum);

            // 时长标签
            LabelDuration = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 134),
                ForeColor = Color.FromArgb(167, 167, 167),
                Location = new Point(Width * 3, (int)(Height * (1 / 7.0))),
            };
            this.Controls.Add(LabelDuration);


            this.SizeChanged += SizeChangedHandler;

            this.MouseEnter += new EventHandler(SongButton_MouseEnter);
            this.MouseLeave += new EventHandler(SongButton_MouseLeave);
            this.MouseDoubleClick += new MouseEventHandler(SongButton_DoubleClick);
        }

        private void SongButton_DoubleClick(object sender, EventArgs e)
        {
            Debug.WriteLine($"Add song to playlist: SongID: {SongID} TitleText: {TitleText} - {ArtistID}");
            Program.musicPlayer.AddSongToListFront(new Core.Entity.Song(SongID, TitleText, ArtistID, ArtistNameText, AlbumID, AlbumText, Properties.Resources.External_URL + "/Album/" + ArtistNameText + "-" + AlbumText + "/" + TitleText + ".flac"));
            Program.musicPlayer.PlayInOrder();
        }

        private void SongButton_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标停留在TrackBar上时的逻辑
            MouseOn = true;
            BackColor = Color.FromArgb(BackColor.R + 8, BackColor.R + 8, BackColor.R + 8);
            ToggleShape();
        }

        // 当鼠标离开TrackBar时触发的方法
        private void SongButton_MouseLeave(object sender, EventArgs e)
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

        public string ArtistNameText
        {
            get => ArtistName.Text;
            set => ArtistName.Text = value;
        }

        public string AlbumText
        {
            get => LabelAlbum.Text;
            set => LabelAlbum.Text = value;
        }

        public string Duration
        {
            get => LabelDuration.Text;
            set => LabelDuration.Text = value;
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
            LabelAlbum.Location = new Point(Width / 2, (int)(Height * (5 / 14.0)));
            LabelDuration.Location = new Point(Width * 8 / 9, (int)(Height * (5 / 14.0)));
        }

        public void ToggleShape()
        {
            Invalidate();
        }
    }
}
