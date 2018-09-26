using System.ComponentModel.DataAnnotations;

namespace Music.Web.Api.Data.Models
{
    public class BandAlbum : IPersistentObject
    {
        public int BandId { get; set; }
        public int AlbumId { get; set; }

        [Key] public int Id { get; set; }
    }
}