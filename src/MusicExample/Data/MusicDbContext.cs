using Microsoft.EntityFrameworkCore;
using UserApi.Data.Models;

namespace UserApi.Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumSong> AlbumSongs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistAlbum> ArtistAlbums { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<BandArtist> BandArtists { get; set; }
        public DbSet<Song> Songs { get; set; }

        public MusicDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}