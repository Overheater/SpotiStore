using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class User
    {
        public String Name { get; set; }
        public int UserID { get; set; }
        public IEnumerable<SimplePlaylist> Playlists { get; set; }

        public User(PublicUser user, List<SimplePlaylist> playlists)
        {
            Name = user.DisplayName;
            UserID = int.Parse(user.Id);
            Playlists = playlists;

        }

    }
}
