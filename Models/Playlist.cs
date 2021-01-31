using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class Playlist
    {
        
        public IEnumerable<Song> PlaylistSongs { get; set; }
        public User Creator { get; set; }

        public Playlist(FullPlaylist playlist)
        {
            
        }

    }
}
