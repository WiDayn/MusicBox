using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Core.Common
{
    public class UrlConverter
    {
        public static string EncodeUrl(string url)
        {
            return Uri.EscapeUriString(url);
        }
    }
}
