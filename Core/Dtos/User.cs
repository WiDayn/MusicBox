using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Dtos
{
    public class UserInfoResponse
    {
        public int StatusCode { get; set; }
        public UserData Data { get; set; }
        public string Message { get; set; }
    }

    public class UserData
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastLogin { get; set; }

        public int FavoriteSongNum { get; set; }
    }
}
