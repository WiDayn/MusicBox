using MusicBox.Core.PlayBack.Player;
using System.Diagnostics;
using Un4seen.Bass; //ÃÌº”“˝”√

namespace MusicBox
{
    internal static class Program
    {
        public static BassPlayer audioPlayer = new();

        [STAThread]
        static void Main()
        {
            Debug.WriteLine("111111");
            ApplicationConfiguration.Initialize();
            audioPlayer.LoadAudio("C:\\Users\\skv\\source\\repos\\MusicBox\\bin\\Debug\\net8.0-windows\\mygo.m4a");
            audioPlayer.Play();
            Application.Run(new MusicBox());
            audioPlayer.Dispose();
        }
    }
}