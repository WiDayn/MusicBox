using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Dtos
{
    public class Album
    {
        public class AlbumInfoResponse
        {
            public int StatusCode { get; set; }
            public AlbumData Data { get; set; }
            public string Message { get; set; }
        }

        public class AlbumData
        {
            public AlbumInfo Album { get; set; }
            public List<SongInfo> Songs { get; set; }
            public string ArtistName { get; set; }
        }

        public class AlbumInfo
        {
            public int AlbumID { get; set; }
            public string Title { get; set; }
            public int ArtistID { get; set; }
            public string Bio { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Distributor { get; set; }
        }

        public class SongInfo
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
