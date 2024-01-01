using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Entity
{
    public class Artist(int artistID)
    {
        public int ArtistID { get; set; } = artistID;
        public int Listener {  get; set; }
        public string? Name { get; set; }
        public string? Bio {  get; set; }
        public string? FacebookLink {  get; set; }
        public string? XLink  { get; set; }
        public string? InsLink { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<int> Songs { get; set; } = [];
        public List<int> Albums { get; set; } = [];
        public List<int> Concert { get; set; } = [];
    }
}
