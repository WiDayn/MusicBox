using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Entity
{
    public class Song(int songID)
    {
        public int SongID { get; set; } = songID;
        public string? Title { get; set; }
        public int ArtistID { get; set; }

        public int AlbumID { get; set; }
        public string? FilePath { get; set; }
    }

}
