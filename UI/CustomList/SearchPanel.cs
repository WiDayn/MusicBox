using MusicBox.API;
using MusicBox.UI.Button;
using MusicBox.UI.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // 确保引入 System.Windows.Forms 命名空间
using static MusicBox.Core.Dtos.Album;
using static MusicBox.Core.Dtos.Artist;

namespace MusicBox.UI.CustomList
{
    internal class SearchPanel : Panel
    {
        private TextBox searchBox; // 定义一个 TextBox 成员变量作为搜索框

        public RecentList SongPanel = new();

        public SearchPanel()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // 创建搜索框
            searchBox = new TextBox();
            searchBox.Size = new Size(400, 20); // 设置宽度为 400，高度为 100
            searchBox.Location = new Point(100, 10); // 设置合适的位置
            searchBox.BackColor = Color.FromArgb(36, 36, 36);
            searchBox.Font = new Font("Microsoft YaHei UI", 25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            searchBox.ForeColor = Color.White;
            searchBox.PlaceholderText = "想听什么？";
            searchBox.KeyDown += new KeyEventHandler(searchBox_KeyDown);
            // 将搜索框添加到面板中
            this.Controls.Add(searchBox);
            // 创建并设置内部的 FlowLayoutPanel
            SongPanel = new RecentList
            {
                Location = new Point(5, 60),
                Width = (int)(Width - (23 * GetScreenScalingFactor())),
                Height = 600,
            };
            this.Controls.Add(SongPanel);

            Layout += (sender, e) => {
                SongPanel.Width = (int)(Width - (23 * GetScreenScalingFactor()));
            };
        }


        private async void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var result = await SongAPI.SearchSongsAsync(searchBox.Text);
                int i = 1;
                SongPanel.Panel.Controls.Clear();
                foreach ( var song in result.Data)
                {
                    SongPanel.AddTrackData((i++).ToString(), Properties.Resources.External_URL + "/Album/" + song.ArtistName + "-" + song.AlbumTitle + "/cover.jpg",
                        song.SongID, song.ArtistID, song.AlbumID, song.Title, song.ArtistName, song.AlbumTitle, song.Duration);
                }
                
                // 阻止声音和其他默认行为
                e.SuppressKeyPress = true;
            }
        }

        public static float GetScreenScalingFactor()
        {
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                float dpiX = graphics.DpiX;
                // 标准 DPI 通常是 96，所以缩放比例是当前 DPI 与 96 的比值
                return dpiX / 96.0f;
            }
        }
    }
}
