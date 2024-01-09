using MusicBox.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Dtos
{
    internal class Song
    {
        public class LyricsResponse
        {
            public int StatusCode { get; set; }
            public string Data { get; set; }
            public string Message { get; set; } = "";
        }

        public class SearchResponse
        {
            public int StatusCode { get; set; }
            public List<SearchSong> Data { get; set; }
            public string Message { get; set; } = "";
        }
    }

    public class SearchSong
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public int AlbumID { get; set; }
        public int ArtistID {  get; set; }
        public string Duration { get; set; }
        public string Genre { get; set; }
        public int BitRate { get; set; }
        public int ViewCount { get; set; }
        public int TrackNumber { get; set; }
        public string AlbumTitle { get; set; }
        public string ArtistName { get; set; }
        // 其他字段根据需要添加
    }
}
