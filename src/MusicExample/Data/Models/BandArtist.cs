using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace UserApi.Data.Models
{
    public class BandArtist : IPersistentObject
    {
        [Key]
        public int Id { get; set; }
        public int BandId { get; set; }
        public int ArtistId { get; set; }
    }
}