using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class Album 
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public string ArtistName { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Album(SimpleAlbum album)
        {
            Name = album.Name;
            ID = album.Id;
            ReleaseDate = DateTime.Parse(album.ReleaseDate);

        }
    }



}
