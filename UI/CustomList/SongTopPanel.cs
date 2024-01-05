using MusicBox.API;
using MusicBox.Core.Entity;
using MusicBox.UI.Button;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicBox.UI.List
{
    public class SongTopPanel : UserControl
    {
        public Panel Panel;

        public SongTopPanel()
        {
            Panel = new Panel();
            Panel.Dock = DockStyle.Fill;
            this.Controls.Add(Panel);
        }

        public async void SetSongTop(String imgPath ,string typeText, string nameText, string descriptionText)
        {
            var songTop = new SongTop
            {
                Width = Width, // 减去滚动条的宽度
                Height = Height,
                Dock = DockStyle.Fill,
            };
            if (imgPath.StartsWith("http"))
            {
                songTop.Image = await ImgAPI.LoadImageFromUrlAsync(imgPath);
            } else
            {
                songTop.Image = Image.FromFile(imgPath);
            }
            
            songTop.TypeText = typeText;
            songTop.NameText = nameText;
            songTop.DescriptionText = descriptionText;
            Panel.Controls.Add(songTop);
        }
        public async void SetSongTopFromIMG(Image image, string typeText, string nameText, string descriptionText)
        {
            var songTop = new SongTop
            {
                Width = Width, // 减去滚动条的宽度
                Height = Height,
                Dock = DockStyle.Fill,
            };
            songTop.Image = image;

            songTop.TypeText = typeText;
            songTop.NameText = nameText;
            songTop.DescriptionText = descriptionText;
            Panel.Controls.Add(songTop);
        }

    }
}
