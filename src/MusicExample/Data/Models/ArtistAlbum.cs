using System.ComponentModel.DataAnnotations;

namespace UserApi.Data.Models
{
    public class ArtistAlbum : IPersistentObject
    {
        [Key]
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
    }
}