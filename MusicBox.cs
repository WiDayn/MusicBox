
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
