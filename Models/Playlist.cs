﻿using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotiStore.Models
{
    public class Playlist
    {

        public List<Song> PlaylistSongs { get; set; }
        public string CreatorID { get; set; }

        public Playlist(FullPlaylist playlist)
        {
            CreatorID = playlist.Owner.Id;
            PlaylistSongs = new List<Song>();

        }
        /// <summary>
        /// takes the list of songs passed to it in the parameters and adds them to the Playlistsongs List
        /// </summary>
        /// <param name="playlist"> a list of spotify api track objects</param>
        /// <returns>A boolean: true for succesful, false for unsuccesful</returns>
        public bool AddPlaylistTrack(PlaylistTrack<IPlayableItem> playlistItem)
        {
            //TODO: get a better name for the list below once you think of one.
            if (playlistItem.Track is FullTrack track)
            {
                try
                {
                    PlaylistSongs.Add(new Song(track, playlistItem.AddedAt));
                    return true;
                }
                catch (Exception e)
                {

                    throw new Exception("there is an issue adding this track", e);
                }
            }
            else 
                return false;
        }
    }

}

