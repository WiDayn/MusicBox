using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Entity
{
    public class PlayList(int playListID, int OwnUserID, string name)
    {
        public int PlayListID { get; set; } = playListID;
        public int OwnUserID { get; set; } = OwnUserID;
        public string Name { get; set; } = name;
        public List<int> songs = [];
        public List<int> invitedUsers = [];
    }
}
