using global::MusicBox.API;
using global::MusicBox.UI.CustomPictureBox;
using MusicBox.Core.Dtos;

namespace MusicBox.UI.Button
{
    public class RecentButton : UserControl
    {
        private CircularPictureBox pictureBox;
        private Label Title;
        private Label Description;
        // type: Like,Album,Artist
        public String Type {  get; set; }

        // 声明一个点击事件
        public event EventHandler ButtonClick;
        public FavoriteResponse favoriteResponse;

        public RecentButton(string type)
        {
            // 设置控件的初始大小
            Size = new Size(300, 100);
            // 创建并设置 PictureBox
            pictureBox = new CircularPictureBox
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
            this.MouseEnter += new EventHandler(RecentButton_MouseEnter);
            this.MouseLeave += new EventHandler(RecentButton_MouseLeave);
            this.MouseClick += new MouseEventHandler(RecentButton_MouseClick);
            if(type == "Like") this.Load += new EventHandler(RecentButton_Load);
        }

        private async void RecentButton_Load(object sender, EventArgs e)
        {
            favoriteResponse = await ListAPI.GetFavoriteSongsAsync();
            DescriptionText = $"歌单 • 已喜欢{favoriteResponse.Data.Count}首歌";
        }

        private async void RecentButton_MouseClick(object sender, MouseEventArgs e)
        {
            // TODO: 更新RightTabControl.(0)里的内容
            Program.DefaultAlbumList.Panel.Controls.Clear();
            int i = 1;

            if(Type == "Like")
            {
                Program.AblumPlayingSongTopPanel.SetSongTopFromIMG(Properties.Resources.MyLove, "歌单", "已点赞的歌", UserAPI.userData.Username + " • " + favoriteResponse.Data.Count.ToString() + "首歌曲");
            }

            foreach (var song in favoriteResponse.Data)
            {
                // 专辑封面的位置是固定的
                Program.DefaultAlbumList.AddTrackData((i++).ToString(), true, Properties.Resources.External_URL + "/Album/" + song.ArtistName + "-" + song.AlbumTitle + "/cover.jpg"
                    , song.Title, song.ArtistName, song.AlbumTitle, song.Duration.ToString());
            }
            Program.DefaultRightTabControl.SwitchToPanel(0);
            ButtonClick?.Invoke(this, EventArgs.Empty);
        }
        private void RecentButton_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标停留在TrackBar上时的逻辑
            BackColor = Color.FromArgb(BackColor.R + 8, BackColor.R + 8, BackColor.R + 8);
            ToggleShape();
        }

        // 当鼠标离开TrackBar时触发的方法
        private void RecentButton_MouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开TrackBar时的逻辑
            BackColor = Color.FromArgb(BackColor.R - 8, BackColor.R - 8, BackColor.R - 8);
            ToggleShape();
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

        // 当鼠标点击时触发
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            // 修改背景颜色
            BackColor = Color.FromArgb(26, 26, 26);
        }

        public void ToggleShape()
        {
            Invalidate();
        }
    }

}
