using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicBox.API;
using MusicBox.Core.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MusicBox.Core.PlayBack.Player
{
    public class MusicPlayer
    {
        public QueuePlayList MusicPlayList;
        public QueuePlayList MusicPlayedList;
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

        public void AddSongToListFront(Song song)
        {
            MusicPlayList.AddSongToFront(song);
        }

        public void PlayInOrder()
        {
            List<Song> songList = MusicPlayList.songs;
            int nowPlaying = 0;
            if (nowPlaying < songList.Count)
            {
                Debug.WriteLine($"Playing: {songList[nowPlaying].Title} by ArtistID: {songList[nowPlaying].ArtistID} From AlbumID: {songList[nowPlaying].AlbumID}");
                bassPlayer.LoadAudio(songList[nowPlaying].FilePath);
                UpdatePlayingUI(songList[nowPlaying]);
                bassPlayer.Play();
                bassPlayer.TrackEnded += (sender, e) =>
                {
                    MusicPlayedList.AddSong(songList[nowPlaying]);
                    nowPlaying++;
                    if (nowPlaying < songList.Count)
                    {
                        bassPlayer.LoadAudio(songList[nowPlaying].FilePath);
                        UpdatePlayingUI(songList[nowPlaying]);
                        bassPlayer.Play();
                    }
                };
            }
        }

        public void UpdatePlayingUI(Song song)
        {
            Program.PlayingSongAlbumPicture.Invoke(new MethodInvoker(async () =>
            {
                Program.PlayingSongAlbumPicture.Image = await ImgAPI.LoadImageFromUrlAsync(Properties.Resources.External_URL + "/Album/" + song.ArtistName + "-" + song.AlbumName + "/cover.jpg");
            }));

            Program.PlayingSongTitleLabel.Invoke(new MethodInvoker(delegate
            {
                Program.PlayingSongTitleLabel.Text = song.Title;
            }));

            Program.PlayingSongArtistLabel.Invoke(new MethodInvoker(delegate
            {
                Program.PlayingSongArtistLabel.Text = song.ArtistName;
            }));
        }

        public float GetVolume()
        {
            return bassPlayer.GetVolume();
        }

        public void SetVolume(float volume)
        {
            bassPlayer.SetVolume(volume);
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

        public void SetCurrentPositionInSeconds(double seconds)
        {
            bassPlayer.SetCurrentPosition(seconds);
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
