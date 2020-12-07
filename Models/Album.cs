using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiStore.Models
{
    public class Album
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public IEnumerable<Song> Songs { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
