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
            musicPlayer.AddSongToList(new Song(1, "春日影", 1, 2, "C:\\Users\\15037\\Desktop\\MusicBox\\1.m4a"));
            musicPlayer.AddSongToList(new Song(2, "タイニーリトル・アジアンタム", 2, 3, "C:\\Users\\15037\\Desktop\\MusicBox\\2.m4a"));
            musicPlayer.PlayInRandom();
            Application.Run(new MusicBox());
            musicPlayer.Dispose();
        }
    }
}