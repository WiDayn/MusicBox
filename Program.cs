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
            musicPlayer.AddSongToList(new Song(1, "春日影", 1, 2, "E:\\External\\Album\\林家谦-SEVEN\\在空中的這一秒.flac"));
            musicPlayer.AddSongToList(new Song(2, "タイニーリトル・アジアンタム", 2, 3, "E:\\External\\Album\\林家谦-SEVEN\\在空中的這一秒.flac"));
            musicPlayer.PlayInRandom();
            Application.Run(new Login());
            musicPlayer.Dispose();
        }
    }
}