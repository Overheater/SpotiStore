using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class API
    {
        /// <summary>
        /// the api key needed to access the spotify api
        /// </summary>
        private string ApiKey { get; set; }
        public SpotifyClient SpotifyClient { get; set; }
        /// <summary>
        /// a counter for the amount of calls to the api, in case of api call limiting being needed
        /// </summary>
        public int Recentcalls { get; set; }
    }
}
