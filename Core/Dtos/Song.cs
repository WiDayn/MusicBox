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
    }
}
