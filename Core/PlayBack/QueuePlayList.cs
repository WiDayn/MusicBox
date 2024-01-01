using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBox.Core.Entity;

namespace MusicBox.Core.PlayBack
{
    internal class QueuePlayList : PlayList
    {
        private Random random;

        public QueuePlayList()
        {
            random = new Random();
        }


        // 打乱播放列表
        public void RandomList()
        {
            List<Song> shuffledSongs = new(songs);
            int n = shuffledSongs.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = shuffledSongs[k];
                shuffledSongs[k] = shuffledSongs[n];
                shuffledSongs[n] = value;
            }

            songs = shuffledSongs;
        }
    }
}
