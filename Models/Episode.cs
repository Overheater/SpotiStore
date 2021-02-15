using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    class Episode: PlaylistItem
    {
        public string Name { get; set; }
        public string Podcast { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime? AddedDate { get; set; }
        public string EpisodeID { get; set; }

        public Episode(FullEpisode episode,DateTime? addedDate)
        {
            Name = episode.Name;
            //TODO: Look into using the Show to a larger extent (IE like the discogs link to artist and album for songs)
            Podcast = episode.Show.Name;
            //Release Date for episodes is for some reason a string: this will inevitably be refactored later on in  api library development so watch out.
            ReleaseDate = DateTime.Parse(episode.ReleaseDate);
            AddedDate = addedDate;
            EpisodeID = episode.Id;
        }


    }
}
