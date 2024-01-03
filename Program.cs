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
            musicPlayer.AddSongToList(new Song(1, "春日影", 1, 2, "http://localhost:5000/external/Album/%E6%9E%97%E5%AE%B6%E8%B0%A6-SEVEN/%E5%9C%A8%E7%A9%BA%E4%B8%AD%E7%9A%84%E9%80%99%E4%B8%80%E7%A7%92.flac"));
            musicPlayer.AddSongToList(new Song(2, "タイニーリトル・アジアンタム", 2, 3, "http://localhost:5000/external/Album/%E6%9E%97%E5%AE%B6%E8%B0%A6-SEVEN/%E5%9C%A8%E7%A9%BA%E4%B8%AD%E7%9A%84%E9%80%99%E4%B8%80%E7%A7%92.flac"));
            musicPlayer.PlayInRandom();
            Application.Run(new MusicBox());
            musicPlayer.Dispose();
        }
    }
}