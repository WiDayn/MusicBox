using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Dtos
{
    public class Artist
    {
        public class ArtistInfoResponse
        {
            public int StatusCode { get; set; }
            public ArtistData Data { get; set; }
            public string Message { get; set; }
        }

        public class ArtistData
        {
            public ArtistInfo Artist { get; set; }
            public List<Album> Albums { get; set; }
            public List<Song> TopSongs { get; set; }
        }

        public class ArtistInfo
        {
            public int ArtistID { get; set; }
            public string Name { get; set; }
            public string Bio { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string InsLink { get; set; }
            public string TwitterLink { get; set; }
            public string FacebookLink { get; set; }
            public int ListenerNum { get; set; }
        }

        public class Album
        {
            public int AlbumID { get; set; }
            public string Title { get; set; }
            public int ArtistID { get; set; }
            public string Bio { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Distributor { get; set; }
        }

        public class Song
        {
            public int SongID { get; set; }
            public string Title { get; set; }
            public int AlbumID { get; set; }
            public string Duration { get; set; }
            public string Genre { get; set; }
            public int BitRate { get; set; }
            public int ViewCount { get; set; }
        }

    }
}
