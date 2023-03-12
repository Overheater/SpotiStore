using CsvHelper;
using ReactiveUI;
using SkiaSharp;
using SpotiStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpotiStore.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {


        string playlistID;
        string playlistName;

        public ICommand Command { get; set; }
        public string PlaylistID
        {
            get => playlistID;
            set =>this.RaiseAndSetIfChanged(ref playlistID, value);
        }
        public string PlaylistName
        {
            get => playlistName;
            set
            {
                playlistName = value;
                RaisePropertyChanged();
            } 
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public async Task<string> QueryPlaylist()
        {
            var playlist = await spotifyClient.Playlists.Get(PlaylistID);
            PlaylistName = playlist.Name;
            RaisePropertyChanged(playlistName);
            return playlist.Name;
        }
        public async Task<bool> ArchivePlaylist()
        {
            if(playlistID == null)
            {
                //TODO: Add error handling here for when a user hasn't queried a playlist yet.

                return false;
            }
            var spotifyPlaylist =  spotifyClient.Playlists.Get(PlaylistID);
            var test = spotifyPlaylist.GetAwaiter().GetResult();
            var playlist = new Playlist(test);
            using (var writer = new StreamWriter("C:\\Users\\ianpo\\Desktop\\Test.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(playlist.PlaylistSongs.Select(p=>(Song)p));
            }
            return true;
        }
        public MainWindowViewModel()
        {
           createSpotifyClient();

        }
        
    }
}
