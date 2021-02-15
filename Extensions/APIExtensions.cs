using SpotiStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotiStore.Extensions
{
    public static class APIExtensions
    {
        public  static async Task<User> GetUser(this API aPI, string userID)
        {
            var user = await aPI.SpotifyClient.UserProfile.Get(userID);
            var playlists = await aPI.SpotifyClient.Playlists.GetUsers(userID);
            //TODO: get null check working to ensure the user is real
            return new User(user, playlists.Items);
        }
        public static async Task<Playlist> GetPlaylist(this API aPI, string PlaylistID)
        {
            var playlist = await aPI.SpotifyClient.Playlists.Get(PlaylistID);
            //TODO: get null check working to ensure the playlist is correct
            return new Playlist(playlist);
        }
    }
}
