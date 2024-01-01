using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBox.Core.Entity;

namespace MusicBox.Core.PlayBack
{
    public class PlayList
    {
        protected List<Song> songs;
        

        public PlayList()
        {
            songs = new List<Song>();
        }

        // 添加歌曲到播放列表
        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        // 按顺序播放
        public IEnumerable<Song> PlayInOrder()
        {
            foreach (var song in songs)
            {
                yield return song;
            }
        }
    }
}
