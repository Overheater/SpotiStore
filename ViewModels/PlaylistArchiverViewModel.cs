using SpotiStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.ViewModels
{
    public class PlaylistArchiverViewModel :ViewModelBase
    {
        public PlaylistArchiverViewModel(API aPI)
        {
            API = aPI;
        }
        private API API;
        private User User;
        public string UserSearchText = "Search Spotify Users";

        public User Get_User(string userId)
        {
            var user = API.GetUser(userId);
            return new User();
        }
    }
}
