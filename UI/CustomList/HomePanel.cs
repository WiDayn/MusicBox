using MusicBox.API;
using MusicBox.UI.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicBox.Core.Dtos.Album;
using static MusicBox.Core.Dtos.Artist;

namespace MusicBox.UI.CustomList
{
    internal class HomePanel : Panel
    {
        private HomePlayList HomePanelRecentAddAlbum;
        private Label HomePanelTitleLabel;
        private RecentAlbumsResponse RecentAlbumsResponse;

        public HomePanel()
        {
            HomePanelTitleLabel = new Label();
            HomePanelRecentAddAlbum = new HomePlayList();

            Controls.Add(HomePanelTitleLabel);
            Controls.Add(HomePanelRecentAddAlbum);
            //
            // HomePanelTitleLabel
            //
            HomePanelTitleLabel.Location = new Point(10, 10);
            HomePanelTitleLabel.AutoSize = true;
            HomePanelTitleLabel.Text = "最近添加的专辑...";
            HomePanelTitleLabel.Font = new Font("Microsoft YaHei UI", 35F, FontStyle.Bold, GraphicsUnit.Point, 134);
            HomePanelTitleLabel.ForeColor = Color.White;
            //
            // HomePanelRecentAddAlbum
            //
            HomePanelRecentAddAlbum.Location = new Point(10, 100);
            HomePanelRecentAddAlbum.Width = Width - (int)(23 * GetScreenScalingFactor());
            HomePanelRecentAddAlbum.Height = Height - (int)(100 * GetScreenScalingFactor());
            HomePanelRecentAddAlbum.AddHomePlayListButton(3, "Album");
            
            Layout += (sender, e) => {
                HomePanelRecentAddAlbum.Width = Width - (int)(23 * GetScreenScalingFactor());
                HomePanelRecentAddAlbum.Height = Height - (int)(100 * GetScreenScalingFactor());
            };

            HomePanelRecentAddAlbum.Load  += new EventHandler(HomePanel_OnVisibleChanged);
            }

        private async void HomePanel_OnVisibleChanged(object sender, EventArgs e)
        {
            HomePanelRecentAddAlbum.ClearAllButton();

            RecentAlbumsResponse = await AlbumAPI.GetRecentAlbumsInfoAsync();

            foreach(int albumID in RecentAlbumsResponse.Data)
            {
                HomePanelRecentAddAlbum.AddHomePlayListButton(albumID, "Album");
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
