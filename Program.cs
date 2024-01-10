using MusicBox.Core.Entity;
using MusicBox.Core.PlayBack;
using MusicBox.Core.PlayBack.Player;
using MusicBox.UI;
using MusicBox.UI.CustomList;
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

        public static PlayButton DownPlayButton;

        public static PlayButton PlayButton;

        public static SongTopPanel AblumPlayingSongTopPanel;

        public static SingerList DefaultSingerList;

        public static RecentList DefaultRecentList;

        public static LyricsPanel DefaultLyricsPanel;


        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DefaultMusicBox = new();
            Application.Run(new Login());
            musicPlayer.Dispose();
        }
    }
}