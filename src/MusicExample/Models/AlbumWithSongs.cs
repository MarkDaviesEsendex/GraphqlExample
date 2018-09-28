using System.Collections.Generic;

namespace Music.Web.Api.Models
{
    public class AlbumWithSongs
    {
        public string Name { get; set; }
        public List<string> Songs { get; set; }
    }
}