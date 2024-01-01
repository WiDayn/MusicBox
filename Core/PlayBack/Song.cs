using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.PlayBack
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string FilePath { get; set; }

        public Song(string title, string artist, string filePath)
        {
            Title = title;
            Artist = artist;
            FilePath = filePath;
        }
    }

}
