
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
            Program.musicPlayer.Start();
        }
    }
}
