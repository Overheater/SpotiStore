using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class Song : PlaylistItem
    {
        public string Name { get; set; }
        public List<Artist> Artist { get; set; }
        public Album Album { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime? AddedDate { get; set; }
        public string SongID { get; set; }


        //TODO: Build out a check on the playlist constructor that makes sure the iplayable Item is a track.
        public Song(FullTrack track,DateTime? addedDate)
        {
            Name = track.Name;
            Artist = GetArtists(track);
            Album = new Album(track.Album);
            ReleaseDate = Album.ReleaseDate;
            SongID = track.Id;
            AddedDate = addedDate;

        }
        public List<Artist> GetArtists(FullTrack track)
        {
            var ArtistList = new List<Artist>();
            track.Artists.ForEach(a => ArtistList.Add(new Artist(a)));
            return ArtistList;
        }
    }
}
