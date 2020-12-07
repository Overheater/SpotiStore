using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class Song
    {
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int SongID { get; set; }

    }
}
