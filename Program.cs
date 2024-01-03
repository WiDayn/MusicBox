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
            musicPlayer.AddSongToList(new Song(1, "春日影", 1, 2, "https://m701.music.126.net/20240103143901/e35f09e9777ae4204a16a7df44601b22/jdyyaac/obj/w5rDlsOJwrLDjj7CmsOj/32387577059/58db/077f/3939/5502c82f2146ae407621fb965301e869.m4a"));
            musicPlayer.AddSongToList(new Song(2, "タイニーリトル・アジアンタム", 2, 3, "https://m701.music.126.net/20240103143901/e35f09e9777ae4204a16a7df44601b22/jdyyaac/obj/w5rDlsOJwrLDjj7CmsOj/32387577059/58db/077f/3939/5502c82f2146ae407621fb965301e869.m4a"));
            musicPlayer.PlayInRandom();
            Application.Run(new MusicBox());
            musicPlayer.Dispose();
        }
    }
}