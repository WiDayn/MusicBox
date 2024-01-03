
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


        private void MusicBox_Load(object sender, EventArgs e)
        {
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

        private void MusicBox_SizeChanged(object sender, EventArgs e)
        {
            PlayButton.Location = new Point(ClientSize.Width / 2 - PlayButton.Width / 2, ClientSize.Height - 63);
            MainSplitContainer.Size = new Size(ClientSize.Width - 10, ClientSize.Height - 75);
            playTrackBar.Size = new Size(ClientSize.Width / 3, 5);
            playTrackBar.Location = new Point(ClientSize.Width / 2 - playTrackBar.Size.Width / 2, ClientSize.Height - 20);
            playTrackBar.Value = 50;
            NowTimeLabel.Location = new Point(playTrackBar.Location.X - NowTimeLabel.Width - 10, playTrackBar.Location.Y - 6);
            EndTimeLabel.Location = new Point(playTrackBar.Location.X + playTrackBar.Width + 10, playTrackBar.Location.Y - 6);
            LeftDownAlbumBox.Location = new Point(10, ClientSize.Height - 70);
            LeftDownSongNameLabel.Location = new Point(LeftDownAlbumBox.Location.X + LeftDownAlbumBox.Width + 5, LeftDownAlbumBox.Location.Y + 5);
            LeftDownArtistsNameLabel.Location = new Point(LeftDownSongNameLabel.Location.X, LeftDownSongNameLabel.Location.Y + LeftDownSongNameLabel.Height + 5);
        }

        private void SecondTimer_Tick(object sender, EventArgs e)
        {
            NowTimeLabel.Text = (int)Program.musicPlayer.GetCurrentPositionInSeconds() / 60 + ":" + String.Format("{0:00}", (int)Program.musicPlayer.GetCurrentPositionInSeconds() % 60);
            EndTimeLabel.Text = (int)Program.musicPlayer.GetTotalDurationInSeconds() / 60 + ":" + String.Format("{0:00}", (int)Program.musicPlayer.GetTotalDurationInSeconds() % 60);
            playTrackBar.Value = (int)(Program.musicPlayer.GetCurrentPositionInSeconds() / Program.musicPlayer.GetTotalDurationInSeconds() * 100);
            playTrackBar.ToggleShape();
        }
    }
}
