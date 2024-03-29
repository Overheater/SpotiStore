﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CsvHelper;
using CsvHelper.Configuration;
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
        private bool archiveEnabled = false;
        public ICommand Command { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
        public bool ArchiveEnabled
        {
            get => archiveEnabled;
            set {
                archiveEnabled = value;
                RaisePropertyChanged();
            }

        }

        public async Task<string> QueryPlaylist()
        {
            SpotifyAPI.Web.FullPlaylist playlist;
            try
            {
                playlist = await spotifyClient.Playlists.Get(PlaylistID);
                PlaylistName = playlist.Name;
                ArchiveEnabled = true;

                RaisePropertyChanged(playlistName);
                return playlist.Name;

            }
            catch (Exception e)
            {
                ArchiveEnabled = false;
                return "No Playlist Found";
            }

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
            await foreach (var item in spotifyClient.Paginate(test.Tracks))
            {
                playlist.AddPlaylistTrack(item);
            }
            var fileLocation = await GetPath();
            if (fileLocation == "") return false;
            using (var writer = new StreamWriter(fileLocation))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<SongMap>();
                csv.WriteRecords(playlist.PlaylistSongs.Select(p=>(Song)p));
            }
            return true;
        }

        public async Task<string> GetPath()
        {

            if(Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Title = "Choose file name",
                    };
                    saveFileDialog.Filters.Add(new FileDialogFilter { Name = "spreadsheets", Extensions = { "csv" } });
                    var outPathStrings = await saveFileDialog.ShowAsync(desktop.MainWindow).ConfigureAwait(false);

                    //var fileresult = task.Result;
                    return String.Join(" ", outPathStrings);
            }

            return "";
        }




        public MainWindowViewModel()
        {
           createSpotifyClient();

        }
        
    }
    public sealed class SongMap : ClassMap<Song>
    {
        public SongMap()
        {
            Map(m => m.SongName);
            Map(m => m.SongArtist);
            Map(m => m.AlbumName);
            Map(m => m.ReleaseDate);
            Map(m => m.AddedDate);
            Map(m => m.SpotifySongID);
            Map(m => m.DiscogsLink);
        }
    }
}
