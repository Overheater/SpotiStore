using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotiStore.Models
{
    public class API
    {
        

        /// <summary>
        /// the api key needed to access the spotify api
        /// </summary>
        private string ApiKey { get; set; }
        public SpotifyClient SpotifyClient { get; set; }

        public static async Task<SpotifyClient> CreateClient()
        {
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest(APICredentials.ClientId, APICredentials.ClientSecret);
            var response = new OAuthClient(config).RequestToken(request).GetAwaiter().GetResult();
            try
            {
                var client = new SpotifyClient(config.WithToken(response.AccessToken));
                return client;
            }
            catch(Exception ex)
            {
                throw new Exception("Spotify Api Client could not be instatiated", ex);
                return null;
            }
            
        }
        /// <summary>
        /// a counter for the amount of calls to the api, in case of api call limiting being needed
        /// </summary>
        public int Recentcalls { get; set; }
    }
}
