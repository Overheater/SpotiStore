using SkiaSharp;
using SpotiStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpotiStore.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public ICommand Command { get; set; }
        public MainWindowViewModel()
        {
           createSpotifyClient();
        }
        
        public PlaylistArchiverViewModel Archiver { get; }
        public string Greeting => "Welcome to Avalonia!";
    }
}
