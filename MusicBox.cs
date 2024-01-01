
using System.Diagnostics;

namespace MusicBox
{
    public partial class MusicBox : Form
    {
        public MusicBox()
        {
            InitializeComponent();
        }

        private void MusicBox_Load(object sender, EventArgs e)
        {
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
            } else
            {
                Program.musicPlayer.Stop();
            }
            
            PlayButton.ToggleShape();
        }

        private void MusicBox_SizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Size Changed!");
            PlayButton.Location = new Point(ClientSize.Width / 2 - PlayButton.Width / 2,
                                        ClientSize.Height - 100 - PlayButton.Height / 2);
        }
    }
}
