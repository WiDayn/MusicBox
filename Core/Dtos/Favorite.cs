using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Dtos
{
    public class FavoriteInfo
    {
        public List<SongInfo> SongInfos { get; set; }
        public List<FavoriteItem> ArtistInfos { get; set; }
        public List<FavoriteItem> AlbumInfos { get; set; }
        public List<FavoriteItem> PlayListInfos { get; set; }

        public FavoriteInfo()
        {
            SongInfos = [];
            ArtistInfos = [];
            AlbumInfos = [];
            PlayListInfos = [];
        }
    }

    public class FavoriteItem
    {
        public int ID { get; set; }
        public DateTime DateFavorited { get; set; }
    }

    public class SongInfo
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public int AlbumID { get; set; }
        public string AlbumTitle { get; set; }
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int Bitrate { get; set; }
        public int ViewCount { get; set; }
        public int TrackNumber { get; set; }
        public DateTime DateFavorited { get; set; }
    }

    public class FavoriteResponse
    {
        public int StatusCode { get; set; }
        public FavoriteInfo Data { get; set; } = new FavoriteInfo();
        public string Message { get; set; } = "";
    }
}
