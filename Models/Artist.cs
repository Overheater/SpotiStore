using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Playlist> Playlists { get; set; }
    }
}
