
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
            Debug.WriteLine(Program.audioPlayer.GetCurrentPositionInSeconds() + " / " + Program.audioPlayer.GetTotalDuration());
            Program.audioPlayer.Stop();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Program.audioPlayer.Play();
        }
    }
}
