using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class User
    {
        public String Name { get; set; }
        public int UserID { get; set; }
        public IEnumerable<Playlist> Playlists { get; set; }
        public IEnumerable<Playlist> FollowedPlaylists { get; set; }

    }
}
