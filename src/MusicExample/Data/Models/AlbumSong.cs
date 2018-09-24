using System.ComponentModel.DataAnnotations;
using UserApi.Data.Models;

namespace Music.Web.Api.Data.Models
{
    public class AlbumSong : IPersistentObject
    {
        public int AlbumId { get; set; }
        public int SongId { get; set; }

        [Key] public int Id { get; set; }
    }
}