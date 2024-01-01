using MusicBox.Core.Entity;
using MusicBox.Core.PlayBack;
using MusicBox.Core.PlayBack.Player;
using System.Diagnostics;
using Un4seen.Bass; //添加引用

namespace MusicBox
{
    internal static class Program
    {
        public static MusicPlayer musicPlayer = new();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            musicPlayer.AddSongToList(new Song("春日影", "MYGO", "C:\\Users\\skv\\source\\repos\\MusicBox\\bin\\Debug\\net8.0-windows\\mygo.m4a"));
            musicPlayer.AddSongToList(new Song("タイニーリトル・アジアンタム", "3L", "C:\\Users\\skv\\Downloads\\tainiiritoru.m4a"));
            musicPlayer.PlayInRandom();
            Application.Run(new MusicBox());
            musicPlayer.Dispose();
        }
    }
}