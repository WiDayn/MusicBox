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
        public int lastPlaying = 0;

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
            if (songList.Count > 0)
            {
                Debug.WriteLine($"Playing: {songList[0].Title} by ArtistID: {songList[0].ArtistID} From AlbumID: {songList[0].AlbumID}");
                bassPlayer.LoadAudio(songList[0].FilePath);
                MusicPlayedList.AddSong(songList[0]);
                UpdatePlayingUI(songList[0]);
                bassPlayer.Play();
                lastPlaying = songList[0].SongID;
                songList.RemoveAt(0);
                bassPlayer.TrackEnded += (sender, e) =>
                {
                    if (songList.Count > 0)
                    {
                        MusicPlayedList.AddSong(songList[0]);
                        bassPlayer.LoadAudio(songList[0].FilePath);
                        UpdatePlayingUI(songList[0]);
                        bassPlayer.Play();
                        lastPlaying = songList[0].SongID;
                        songList.RemoveAt(0);
                    }
                };
            }
        }

        public void ClearPlayList()
        {
            MusicPlayList.songs.Clear();
        }

        public void PlayNext()
        {
            List<Song> songList = MusicPlayList.songs;
            if (songList.Count > 0)
            {
                Debug.WriteLine($"Playing: {songList[0].Title} by ArtistID: {songList[0].ArtistID} From AlbumID: {songList[0].AlbumID}");
                bassPlayer.LoadAudio(songList[0].FilePath);
                MusicPlayedList.AddSong(songList[0]);
                UpdatePlayingUI(songList[0]);
                bassPlayer.Play();
                lastPlaying = songList[0].SongID;
                songList.RemoveAt(0);
            }
        }

        public void PlayLast()
        {
            if (MusicPlayedList.songs.Count > 1)
            {
                AddSongToListFront(MusicPlayedList.songs[MusicPlayedList.songs.Count - 1]);
                AddSongToListFront(MusicPlayedList.songs[MusicPlayedList.songs.Count - 2]);
                MusicPlayedList.songs.RemoveAt(MusicPlayedList.songs.Count - 1);
                MusicPlayedList.songs.RemoveAt(MusicPlayedList.songs.Count - 1);
                PlayNext();
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
