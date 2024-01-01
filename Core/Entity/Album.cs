using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Entity
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string? Title { get; set; }
        public DateTime? ReleseDate { get; set; }
        public string? Distributor { get; set; }
    }
}
