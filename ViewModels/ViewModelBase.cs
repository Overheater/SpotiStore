using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using SpotifyAPI.Web;
using SpotiStore.Models;

namespace SpotiStore.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public SpotifyClient spotifyClient;
        public bool createSpotifyClient()
        {
            try
            {
                var clientTask =  API.CreateClient();
                spotifyClient = clientTask.GetAwaiter().GetResult();
                return true;
            }
            catch (Exception e)
            {
                return false;
            } 
        }
    }
}
