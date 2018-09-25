using System.ComponentModel.DataAnnotations;

namespace Music.Web.Api.Data.Models
{
    public class ArtistAlbum : IPersistentObject
    {
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }

        [Key] public int Id { get; set; }
    }
}