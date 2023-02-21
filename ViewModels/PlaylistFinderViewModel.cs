using ReactiveUI;
using SpotiStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.ViewModels
{
    public class PlaylistFinderViewModel :ViewModelBase
    {
        string playlistID;
        string PlaylistName { get; set; }
        public PlaylistFinderViewModel()
        {
        }


        //public User Get_User(string userId)
        //{
        //    var user = API.GetUser(userId);
        //    return new User();
        //}

    }
}
