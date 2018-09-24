using Microsoft.EntityFrameworkCore;
using Music.Web.Api.Data.Models;
using UserApi.Data.Models;

namespace Music.Web.Api.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumSong> AlbumSongs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistAlbum> ArtistAlbums { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<BandMember> BandArtists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}