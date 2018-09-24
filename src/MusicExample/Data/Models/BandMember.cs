using System.ComponentModel.DataAnnotations;

namespace Music.Web.Api.Data.Models
{
    public class BandMember : IPersistentObject
    {
        public int BandId { get; set; }
        public int ArtistId { get; set; }

        [Key] public int Id { get; set; }
    }
}