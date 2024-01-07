using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Dtos
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Data { get; set; }
        public string Message { get; set; }
    }
}
