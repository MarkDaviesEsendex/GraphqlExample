using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Web.Api.Data.Models
{
    public class BandAlbum : IPersistentObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", Order = 1)]
        public int Id { get; set; }

        public int BandId { get; set; }

        public int AlbumId { get; set; }
    }
}