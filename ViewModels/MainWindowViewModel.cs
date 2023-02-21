using ReactiveUI;
using SkiaSharp;
using SpotiStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public void ArchivePlaylist()
        {
            return;
        }
        public MainWindowViewModel()
        {
           createSpotifyClient();

        }
        
    }
}
