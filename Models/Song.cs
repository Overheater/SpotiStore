﻿using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace SpotiStore.Models
{
    public class Song : PlaylistItem
    {
        public string SongName { get; set; }
        public string SongArtist { get; set; }
        //switched to string due to the limitations in CSVhelper
        //public List<Artist> Artist { get; set; }
        public Album SongAlbum { get; set; }
        public string ReleaseDate { get; set; }
        public DateTime? AddedDate { get; set; }
        public string SpotifySongID { get; set; }
        public string DiscogsLink { get; set; }


        //TODO: Build out a check on the playlist constructor that makes sure the iplayable Item is a track.
        public Song(FullTrack track,DateTime? addedDate)
        {
            SongName = track.Name;
            SongArtist = GetArtists(track);
            SongAlbum = new Album(track.Album);
            ReleaseDate = SongAlbum.ReleaseDate;
            SpotifySongID = track.Id;
            AddedDate = addedDate;

        }
        public string GetArtists(FullTrack track)
        {   string ArtistList;
            if (track.Artists.Count > 1)
                ArtistList = string.Join(", ", track.Artists.Select(a => a.Name));
            else
                ArtistList = track.Artists[0].Name;
            return ArtistList;
        }
    }
}
