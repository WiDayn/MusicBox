using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBox.Core.Entity;

namespace MusicBox.Core.PlayBack
{
    public class QueuePlayList
    {
        public List<Song> songs;
        public Random random;

        public QueuePlayList()
        {
            songs = new List<Song>();
            random = new Random();
        }

        // 添加歌曲到播放列表
        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        public void AddSongToFront(Song song)
        {
            songs.Insert(0, song);
        }

        // 按顺序播放
        public IEnumerable<Song> PlayInOrder()
        {
            foreach (var song in songs)
            {
                yield return song;
            }
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
