using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Entity
{
    public class Song(int songID, string title, int artistID, string artistName, int albumID, string albumName, string filePath)
    {
        public int SongID { get; set; } = songID;
        public string Title { get; set; } = title;
        public int ArtistID { get; set; } = artistID;
        public string ArtistName {  get; set; } = artistName;
        public int AlbumID { get; set; } = albumID;
        public string AlbumName { get; set; } = albumName;
        public string FilePath { get; set; } = filePath;
    }

}
