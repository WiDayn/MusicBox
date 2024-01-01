using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBox.Core.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MusicBox.Core.PlayBack.Player
{
    public class MusicPlayer
    {
        private QueuePlayList MusicPlayList;
        private QueuePlayList MusicPlayedList;
        private BassPlayer bassPlayer;

        public MusicPlayer() 
        { 
            MusicPlayList= new QueuePlayList();
            MusicPlayedList = new QueuePlayList();
            bassPlayer = new BassPlayer();
        }

        public void AddSongToList(Song song)
        {
            MusicPlayList.AddSong(song);
        }

        public void PlayInOrder()
        {
            IEnumerator<Song> songList = MusicPlayList.PlayInOrder().GetEnumerator();
            songList.MoveNext();
            Debug.WriteLine($"Playing: {songList.Current.Title} by {songList.Current.Artist}");
            bassPlayer.LoadAudio(songList.Current.FilePath);
            bassPlayer.Play();
            bassPlayer.TrackEnded += (sender, e) =>
            {
                MusicPlayedList.AddSong(songList.Current);
                if (songList.MoveNext())
                {
                    bassPlayer.LoadAudio(songList.Current.FilePath);
                    bassPlayer.Play();
                }
            };
        }

        public void PlayInRandom()
        {
            MusicPlayList.RandomList();
            PlayInOrder();
        }

        public double GetCurrentPositionInSeconds()
        {
            return bassPlayer.GetCurrentPositionInSeconds();
        }

        public double GetTotalDurationInSeconds()
        {
            return bassPlayer.GetTotalDurationInSeconds();
        }

        public void Start()
        {
            bassPlayer.Play();
        }

        public void Stop()
        {
            bassPlayer.Stop();
        }

        public void Dispose()
        {
            bassPlayer.Dispose();
        }
    }
}
