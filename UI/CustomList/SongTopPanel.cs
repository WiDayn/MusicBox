﻿using MusicBox.Core.Entity;
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
            this.Controls.Add(Panel);

            this.SizeChanged += SizeChangedHandler;
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            foreach (SongTop item in Panel.Controls)
            {
                item.Width = Width;
                item.Height = Height;
            }

            Panel.Size = new Size(Width, Height);
        }

        public void AddSongTop(String imgPath, string titleText, string descriptionText)
        {
            var songTop = new SongTop
            {
                Width = Width, // 减去滚动条的宽度
                Height = Height,
            };
            songTop.Image = Image.FromFile(imgPath);
            songTop.TitleText = titleText;
            songTop.DescriptionText = descriptionText;
            Panel.Controls.Add(songTop);
        }
    }
}
