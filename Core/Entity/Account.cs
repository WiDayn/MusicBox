using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Entity
{
    public class Account(int userID, string username, string nickName)
    {
        public int UserID { get; set; } = userID;
        public string? Email { get; set; }
        public string? Username { get; set; } = username;
        public string? NickName { get; set; } = nickName;
        public DateTime? CredAt { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
