using System.ComponentModel.DataAnnotations;

namespace UserApi.Data.Models
{
    public class AlbumSong : IPersistentObject
    {
        [Key]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }
    }
}