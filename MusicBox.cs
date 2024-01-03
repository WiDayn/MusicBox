
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MusicBox
{
    public partial class MusicBox : Form
    {
        //
        // 调整非客户区颜色为黑色
        //
        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public MusicBox()
        {
            InitializeComponent();
            int TitlebarDarkColour = 0x000000;
            DwmSetWindowAttribute(this.Handle, 35, ref TitlebarDarkColour, System.Runtime.InteropServices.Marshal.SizeOf(TitlebarDarkColour));
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

        private void MusicBox_Load(object sender, EventArgs e)
        {
            RightTabControl.AddPanel(AlbumPanel);
            RightTabControl.AddPanel(ArtistPanel);
            RightTabControl.SwitchToPanel(1);
            MusicBox_SizeChanged(sender, e);
        }

        private void StopButton_click(object sender, EventArgs e)
        {
            Debug.WriteLine(Program.musicPlayer.GetCurrentPositionInSeconds() + " / " + Program.musicPlayer.GetTotalDurationInSeconds());
            Program.musicPlayer.Stop();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (PlayButton.isPlaying)
            {
                Program.musicPlayer.Start();
            }
            else
            {
                Program.musicPlayer.Stop();
            }

            PlayButton.ToggleShape();
        }

        private void PlayTrackBar_Scroll(object sender, EventArgs e)
        {
            Program.musicPlayer.SetCurrentPositionInSeconds(playTrackBar.Value * 1.0 / 100 * Program.musicPlayer.GetTotalDurationInSeconds());

            playTrackBar.ToggleShape();
        }

        private void SplitterMoved_SizeChanged(object sender, EventArgs e)
        {
            LeftTopPanel.Size = new Size(MainSplitContainer.Panel1.Width - (int)(7 * GetScreenScalingFactor()), (int)(130 * GetScreenScalingFactor()));
            LeftDownPanel.Size = new Size(MainSplitContainer.Panel1.Width - (int)(7 * GetScreenScalingFactor()), ClientSize.Height - (int)(75 * GetScreenScalingFactor()) - LeftDownPanel.Location.Y);
            RightTabControl.Location = new Point((int)(7 * GetScreenScalingFactor()), 0);
            RightTabControl.Size = new Size(MainSplitContainer.Panel2.Width - (int)(7 * GetScreenScalingFactor()), MainSplitContainer.Panel2.Height);
        }

        private void MusicBox_SizeChanged(object sender, EventArgs e)
        {
            PlayButton.Location = new Point(ClientSize.Width / 2 - PlayButton.Width / 2,
                                        (int)(ClientSize.Height - 63 * GetScreenScalingFactor()));
            NextButton.Location = new Point(ClientSize.Width / 2 - NextButton.Width / 2 + (int)(45 * GetScreenScalingFactor()),
                            ClientSize.Height - (int)(63 * GetScreenScalingFactor()));
            LastButton.Location = new Point(ClientSize.Width / 2 - LastButton.Width / 2 - (int)(45 * GetScreenScalingFactor()),
                            ClientSize.Height - (int)(63 * GetScreenScalingFactor()));
            MainSplitContainer.Size = new Size(ClientSize.Width - (int)(10 * GetScreenScalingFactor()), ClientSize.Height - (int)(75 * GetScreenScalingFactor()));
            playTrackBar.Size = new Size(ClientSize.Width / 3, (int)(45 * GetScreenScalingFactor()));
            playTrackBar.Location = new Point(ClientSize.Width / 2 - playTrackBar.Size.Width / 2, ClientSize.Height - (int)(20 * GetScreenScalingFactor()));
            playTrackBar.Value = 50;
            VolumeTrackBar.Size = new Size((int)(115 * GetScreenScalingFactor()), (int)(10 * GetScreenScalingFactor()));
            NowTimeLabel.Location = new Point(playTrackBar.Location.X - NowTimeLabel.Width - (int)(10 * GetScreenScalingFactor()), playTrackBar.Location.Y - (int)(6 * GetScreenScalingFactor()));
            EndTimeLabel.Location = new Point(playTrackBar.Location.X + playTrackBar.Width + (int)(10 * GetScreenScalingFactor()), playTrackBar.Location.Y - (int)(6 * GetScreenScalingFactor()));
            LeftDownAlbumBox.Location = new Point(10, ClientSize.Height - (int)(70 * GetScreenScalingFactor()));
            LeftDownSongNameLabel.Location = new Point(LeftDownAlbumBox.Location.X + LeftDownAlbumBox.Width + (int)(5 * GetScreenScalingFactor()), LeftDownAlbumBox.Location.Y + (int)(5 * GetScreenScalingFactor()));
            LeftDownArtistsNameLabel.Location = new Point(LeftDownSongNameLabel.Location.X, LeftDownSongNameLabel.Location.Y + LeftDownSongNameLabel.Height + (int)(5 * GetScreenScalingFactor()));
            SplitterMoved_SizeChanged(sender, e);
        }

        private void SecondTimer_Tick(object sender, EventArgs e)
        {
            NowTimeLabel.Text = (int)Program.musicPlayer.GetCurrentPositionInSeconds() / 60 + ":" + String.Format("{0:00}", (int)Program.musicPlayer.GetCurrentPositionInSeconds() % 60);
            EndTimeLabel.Text = (int)Program.musicPlayer.GetTotalDurationInSeconds() / 60 + ":" + String.Format("{0:00}", (int)Program.musicPlayer.GetTotalDurationInSeconds() % 60);
            playTrackBar.Value = (int)(Program.musicPlayer.GetCurrentPositionInSeconds() / Program.musicPlayer.GetTotalDurationInSeconds() * 100);
            playTrackBar.ToggleShape();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //播放下一首
        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            //播放上一首
        }

        private void MainSplitContainer_Panel1_SizeChanged(object sender, EventArgs e)
        {
            // 更新SearchButton的大小，使其与MainSplitContainer.Panel1的宽度相同，高度为35
            SearchButton.Size = new Size(MainSplitContainer.Panel1.Width, 35);
            HomeButton.Size = new Size(MainSplitContainer.Panel1.Width, 35);
        }

        private void MainSplitContainer_Panel2_SizeChanged(object sender, EventArgs e)
        {
            AlbumView.Size = new Size(MainSplitContainer.Panel2.Width, MainSplitContainer.Panel2.Height * 6 / 10);
            AlbumView.Location = new Point(0, MainSplitContainer.Panel2.Height * 4 / 10);

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            RightTabControl.SwitchToPanel(0);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            RightTabControl.SwitchToPanel(1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
