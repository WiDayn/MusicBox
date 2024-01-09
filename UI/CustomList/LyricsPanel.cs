using MusicBox.Core.Entity;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.UI.CustomList
{
    using global::MusicBox.API;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using static global::MusicBox.Core.Dtos.Song;
    using static System.Windows.Forms.LinkLabel;

    public class LyricsPanel : FlowLayoutPanel
    {
        private List<LrcLine> _lyrics;
        private Timer _timer;

        private LyricsResponse LyricsResponse;
        private int lastID = 0;

        public LyricsPanel()
        {
            _lyrics = new List<LrcLine>();
            _timer = new Timer();
            _timer.Interval = 500; // 更新间隔
            _timer.Tick += Timer_Tick;
            _timer.Start();
            FlowDirection = FlowDirection.TopDown;
            WrapContents = false;
            AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan currentTime = TimeSpan.FromSeconds(Program.musicPlayer.GetCurrentPositionInSeconds());
            UpdateLyricsDisplay(currentTime);
        }

        public void LoadLyrics(string lrcContent)
        {
            _lyrics = LrcParser.ParseLrc(lrcContent);
            CreateLyricsLabels();
        }

        private void CreateLyricsLabels()
        {
            this.Controls.Clear();
            if(_lyrics.Count == 0)
            {
                var label = new Label
                {
                    Text = "本歌曲暂无歌词或为纯音乐",
                    ForeColor = Color.FromArgb(170, 170, 170),
                    Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 134),
                    AutoSize = true,
                    MaximumSize = new Size(this.Width, 0)
                };
                this.Controls.Add(label);
            }
            foreach (var line in _lyrics)
            {
                var label = new Label
                {
                    Text = line.Lyrics,
                    ForeColor = Color.FromArgb(170, 170, 170),
                    Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 134),
                    AutoSize = true,
                    MaximumSize = new Size(this.Width, 0)
                };
                double now = line.Time.TotalSeconds;
                label.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    Program.musicPlayer.SetCurrentPositionInSeconds(now);
                });
                this.Controls.Add(label);
            }
        }

        private async void UpdateLyricsDisplay(TimeSpan currentTime)
        {
            if (Program.musicPlayer.lastPlaying != 0 && Program.musicPlayer.lastPlaying != lastID)
            {
                LyricsResponse lyrics = await SongAPI.GetLyricsAsync(Program.musicPlayer.lastPlaying);
                lastID = Program.musicPlayer.lastPlaying;
                LoadLyrics(lyrics.Data);
            }
            int labelIndex = 0;
            foreach (var line in _lyrics)
            {
                if (labelIndex < this.Controls.Count && this.Controls[labelIndex] is Label label)
                {
                    label.ForeColor = currentTime >= line.Time ? Color.White : Color.FromArgb(170, 170, 170);
                }
                labelIndex++;
            }
        }
    }

}
