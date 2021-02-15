using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotiStore.Models
{
    public class Playlist
    {
        
        public IEnumerable<PlaylistItem> PlaylistSongs { get; set; }
        public string CreatorID { get; set; }

        public Playlist(FullPlaylist playlist)
        {
            PlaylistSongs = APItoProgram(playlist);
            CreatorID = playlist.Owner.Id;

        }
        IEnumerable<PlaylistItem> APItoProgram(FullPlaylist playlist)
        {
            //TODO: get a better name for the list below once you think of one.
             List<PlaylistItem> middle = new List<PlaylistItem>();
             foreach(var item in playlist.Tracks.Items)
            {
                if(item.Track is FullTrack track)
                {
                    middle.Add(new Song(track,item.AddedAt));
                }
                else if(item.Track is FullEpisode episode)
                {
                    middle.Add(new Episode(episode, item.AddedAt));
                }
            }
            return middle;
        }

    }
}
