using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Entity
{
    public class Song(int songID, string title, int artistID, int albumID, string filePath)
    {
        public int SongID { get; set; } = songID;
        public string Title { get; set; } = title;
        public int ArtistID { get; set; } = artistID;
        public int AlbumID { get; set; } = albumID;
        public string FilePath { get; set; } = filePath;
    }

}
