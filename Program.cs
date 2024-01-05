using MusicBox.Core.Entity;
using MusicBox.Core.PlayBack;
using MusicBox.Core.PlayBack.Player;
using MusicBox.UI;
using MusicBox.UI.CustomPictureBox;
using MusicBox.UI.List;
using System.Diagnostics;
using Un4seen.Bass; //添加引用

namespace MusicBox
{
    internal static class Program
    {
        public static MusicPlayer musicPlayer = new();

        public static MusicBox DefaultMusicBox;

        public static RecentList DefaultAlbumList;

        public static BorderlessTabControl DefaultRightTabControl;

        public static HttpClient httpClient = new();

        public static Label PlayingSongTitleLabel;

        public static Label PlayingSongArtistLabel;

        public static PictureBox PlayingSongAlbumPicture;

        public static PlayButton PlaySongButton;
        public static PlayButton PlayButton;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            musicPlayer.PlayInRandom();
            DefaultMusicBox = new();
            Application.Run(DefaultMusicBox);
            musicPlayer.Dispose();
        }
    }
}