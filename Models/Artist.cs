using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class Artist
    {
        public string ArtistID { get; set; }
        public string ArtistName { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Playlist> Playlists { get; set; }


        /// <summary>
        /// constructor for track artist info.
        /// </summary>
        /// <param name="artist"></param>
        public Artist(SimpleArtist artist)
        {
            ArtistID = artist.Id;
            ArtistName = artist.Name;
        }
    }
}
