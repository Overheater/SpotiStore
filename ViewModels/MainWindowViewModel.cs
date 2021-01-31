using SpotiStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(API aPI)
        {
            Archiver = new PlaylistArchiverViewModel(aPI);
        }
        public PlaylistArchiverViewModel Archiver { get; }
        public string Greeting => "Welcome to Avalonia!";
    }
}
