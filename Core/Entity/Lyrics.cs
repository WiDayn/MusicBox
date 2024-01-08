using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicBox.Core.Entity
{
    public class LrcLine
    {
        public TimeSpan Time { get; set; }
        public string Lyrics { get; set; }
    }
    public static class LrcParser
    {
        public static List<LrcLine> ParseLrc(string lrcContent)
        {
            var lines = new List<LrcLine>();
            var regex = new Regex(@"\[(\d{2}):(\d{2}\.\d+)\]");
            var matches = regex.Matches(lrcContent);

            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                var nextIndex = (i < matches.Count - 1) ? matches[i + 1].Index : lrcContent.Length;

                var timeStr = match.Value;
                var lyricsStart = match.Index + timeStr.Length;
                var lyricsLength = nextIndex - lyricsStart;
                var lyrics = lrcContent.Substring(lyricsStart, lyricsLength).Trim();

                var minutes = int.Parse(match.Groups[1].Value);
                var seconds = double.Parse(match.Groups[2].Value);

                lines.Add(new LrcLine
                {
                    Time = TimeSpan.FromMinutes(minutes).Add(TimeSpan.FromSeconds(seconds)),
                    Lyrics = lyrics
                });
            }

            return lines;
        }
    }


}
