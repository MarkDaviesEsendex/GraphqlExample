using System;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Music.Web.Api.Data;
using Music.Web.Api.Data.Models;

namespace Music.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<MusicDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }

            host.Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) 
            => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }

    public static class DbInitializer
    {
        public static void Initialize(MusicDbContext context)
        {
            var bands = new List<Band>
            {
                new Band {Id = 1, Name = "Queen"},
                new Band {Id = 2, Name = "ABBA"},
                new Band {Id = 3, Name = "Pink Floyd"},
                new Band {Id = 4, Name = "Judas Priest"},
                new Band {Id = 5, Name = "Boston"},
                new Band {Id = 6, Name = "Aqua"},
                new Band {Id = 7, Name = "Toto"},
                new Band {Id = 8, Name = "Black Sabbath"} 
            };
            context.Bands.AddRange(bands);

            var artists = new List<Artist>
            {
                //Queen
                new Artist {Id = 1, Name = "Freddie Mercury"},
                new Artist {Id = 2, Name = "Brian May"},
                new Artist {Id = 3, Name = "Roger Taylor"},
                new Artist {Id = 4, Name = "John Deacon"},
                
                //Abba
                new Artist {Id = 5, Name = "Agnetha Fältskog"},
                new Artist {Id = 6, Name = "Björn Ulvaeus"},
                new Artist {Id = 7, Name = "Benny Andersson"},
                new Artist {Id = 8, Name = "Anni-Frid Lyngstad"},
                
                // Pink floyd
                new Artist {Id = 9, Name = "Nick Mason"},
                new Artist {Id = 10, Name = "Roger Waters"},
                new Artist {Id = 11, Name = "Richard Wright"},
                new Artist {Id = 12, Name = "Syd Barrett"},
                new Artist {Id = 13, Name = "David Gilmour"},
                
                // Judas Priest
                new Artist {Id = 14, Name = "Ian Hill"},
                new Artist {Id = 15, Name = "Rob Halford"},
                new Artist {Id = 16, Name = "Glenn Tipton"},
                new Artist {Id = 17, Name = "Scott Travis"},
                new Artist {Id = 18, Name = "Richie Faulkner"},
                
                // Boston
                new Artist {Id = 19, Name = "Tom Scholz"},
                new Artist {Id = 20, Name = "Gary Pihl"},
                new Artist {Id = 21, Name = "Curly Smith"},
                new Artist {Id = 22, Name = "Jeff Neal"},
                new Artist {Id = 23, Name = "Tommy DeCarlo"},
                new Artist {Id = 24, Name = "Tracy Ferrie"},
                new Artist {Id = 25, Name = "Beth Cohen"},
                
                // Aqua
                new Artist {Id = 26, Name = "Lene Nystrøm"},
                new Artist {Id = 27, Name = "René Dif"},
                new Artist {Id = 28, Name = "Søren Rasted"},
                
                // Toto
                new Artist {Id = 29, Name = "Steve Lukather"},
                new Artist {Id = 30, Name = "David Paich"},
                new Artist {Id = 31, Name = "Steve Porcaro"},
                new Artist {Id = 32, Name = "Joseph Williams"},
                
                // Sabbath
                new Artist {Id = 33, Name = "Tony Iommi"},
                new Artist {Id = 34, Name = "Geezer Butler"},
                new Artist {Id = 35, Name = "Ozzy Osbourne"},
                
            };
            context.Artists.AddRange(artists);

            var bandArtists = new List<BandMember>
            {
                //Queen
                new BandMember {BandId = 1, ArtistId = 1},
                new BandMember {BandId = 1, ArtistId = 2},
                new BandMember {BandId = 1, ArtistId = 3},
                new BandMember {BandId = 1, ArtistId = 4},
                
                // Abba
                new BandMember {BandId = 2, ArtistId = 5},
                new BandMember {BandId = 2, ArtistId = 6},
                new BandMember {BandId = 2, ArtistId = 7},
                new BandMember {BandId = 2, ArtistId = 8},
                
                // Pink floyd
                new BandMember {BandId = 3, ArtistId = 9},
                new BandMember {BandId = 3, ArtistId = 10},
                new BandMember {BandId = 3, ArtistId = 11},
                new BandMember {BandId = 3, ArtistId = 12},
                new BandMember {BandId = 3, ArtistId = 13},
                
                // Judas Priest
                new BandMember {BandId = 4, ArtistId = 14},
                new BandMember {BandId = 4, ArtistId = 15},
                new BandMember {BandId = 4, ArtistId = 16},
                new BandMember {BandId = 4, ArtistId = 17},
                new BandMember {BandId = 4, ArtistId = 18},
                
                // Boston
                new BandMember {BandId = 5, ArtistId = 19},
                new BandMember {BandId = 5, ArtistId = 20},
                new BandMember {BandId = 5, ArtistId = 21},
                new BandMember {BandId = 5, ArtistId = 22},
                new BandMember {BandId = 5, ArtistId = 23},
                new BandMember {BandId = 5, ArtistId = 24},
                new BandMember {BandId = 5, ArtistId = 25},
                
                // Aqua
                new BandMember {BandId = 6, ArtistId = 26},
                new BandMember {BandId = 6, ArtistId = 27},
                new BandMember {BandId = 6, ArtistId = 28},
                
                // Toto
                new BandMember {BandId = 7, ArtistId = 29},
                new BandMember {BandId = 7, ArtistId = 30},
                new BandMember {BandId = 7, ArtistId = 31},
                new BandMember {BandId = 7, ArtistId = 32},
                
                // Sabbath
                new BandMember {BandId = 8, ArtistId = 33},
                new BandMember {BandId = 8, ArtistId = 34},
                new BandMember {BandId = 8, ArtistId = 35},
            };
            context.BandArtists.AddRange(bandArtists);

            var albums = new List<Album>
            {
                new Album {Id = 1, Name = "A Kind of Magic"},
                new Album {Id = 2, Name = "ABBA"},
                new Album {Id = 3, Name = "The Dark Side of the Moon"},
                new Album {Id = 4, Name = "Painkiller"},
                new Album {Id = 5, Name = "Boston"},
                new Album {Id = 6, Name = "Aquarium"},
                new Album {Id = 7, Name = "Toto IV"},
                new Album {Id = 8, Name = "Paranoid"},
            };
            context.Albums.AddRange(albums);
            
            var songs = new List<Song>
            {
                // A Kind of Magic
                new Song{Id = 1, Name = "One Vision"},
                new Song{Id = 2, Name = "A Kind of Magic"},
                new Song{Id = 3, Name = "Princes of the Universe"},
                new Song{Id = 4, Name = "One Year of Love"},
                new Song{Id = 5, Name = "Friends Will Be Friends"},
                new Song{Id = 6, Name = "Pain Is So Close to Pleasure"},
                new Song{Id = 7, Name = "Who Wants to Live Forever"},
                
                // ABBA
                new Song{Id = 8, Name = "So Long"},
                new Song{Id = 9, Name = "I've Been Waiting for You"},
                new Song{Id = 10, Name = "I Do, I Do, I Do, I Do, I Do"},
                new Song{Id = 11, Name = "Bang-A-Boomerang"},
                new Song{Id = 12, Name = "SOS"},
                new Song{Id = 13, Name = "Mamma Mia"},
                new Song{Id = 14, Name = "Rock Me"},
                
                // The Dark Side of the Moon
                new Song{Id = 15, Name = "Speak to Me"},
                new Song{Id = 16, Name = "Breathe"},
                new Song{Id = 17, Name = "On the Run"},
                new Song{Id = 18, Name = "Time"},
                new Song{Id = 19, Name = "The Great Gig in the Sky"},
                new Song{Id = 20, Name = "Money"},
                new Song{Id = 21, Name = "Us and Them"},
                new Song{Id = 22, Name = "Any Colour You Like"},
                new Song{Id = 23, Name = "Brain Damage"},
                new Song{Id = 24, Name = "Eclipse"},
                
                // Painkiller
                new Song{Id = 25, Name = "Painkiller"},
                new Song{Id = 26, Name = "A Touch of Evil"},
                
                // Boston
                new Song{Id = 27, Name = "More Than a Feeling"},
                new Song{Id = 28, Name = "Peace of Mind"},
                new Song{Id = 29, Name = "Foreplay / Long Time"},
                new Song{Id = 30, Name = "Rock & Roll Band"},
                new Song{Id = 31, Name = "Smokin'"},
                new Song{Id = 32, Name = "Hitch a Ride"},
                new Song{Id = 33, Name = "Something About You"},
                new Song{Id = 34, Name = "Let Me Take You Home Tonight"},
              
                // Aquarium
                new Song{Id = 35, Name = "Happy Boys & Girls"},
                new Song{Id = 36, Name = "My Oh My"},
                new Song{Id = 37, Name = "Barbie Girl"},
                new Song{Id = 38, Name = "Good Morning Sunshine"},
                new Song{Id = 39, Name = "Doctor Jones"},
                new Song{Id = 40, Name = "Heat Of The Night"},
                new Song{Id = 41, Name = "Be A Man"},
                new Song{Id = 42, Name = "Lollipop (Candyman)"},
                new Song{Id = 43, Name = "Roses Are Red"},
                new Song{Id = 44, Name = "Turn Back Time"},
                new Song{Id = 45, Name = "Calling You"},
                
                // Toto IV
                new Song{Id = 46, Name = "Rosanna"},
                new Song{Id = 47, Name = "Make Believe"},
                new Song{Id = 48, Name = "I Won't Hold You Back"},
                new Song{Id = 49, Name = "Good for You"},
                new Song{Id = 50, Name = "It's a Feeling"},
                new Song{Id = 51, Name = "Afraid of Love"},
                new Song{Id = 52, Name = "Lovers in the Night"},
                new Song{Id = 53, Name = "We Made It"},
                new Song{Id = 54, Name = "Waiting for Your Love"},
                new Song{Id = 55, Name = "Africa"},
                
                // Paranoid
                new Song{Id = 56, Name = "War Pigs"},
                new Song{Id = 57, Name = "Paranoid"},
                new Song{Id = 58, Name = "Planet Caravan"},
                new Song{Id = 59, Name = "Iron Man"},
                new Song{Id = 60, Name = "Electric Funeral"},
                new Song{Id = 61, Name = "Hand of Doom"},
                new Song{Id = 62, Name = "Rat Salad"},
                new Song{Id = 63, Name = "Fairies Wear Boots"},
            };
            context.Songs.AddRange(songs);

            var albumSongs = new List<AlbumSong>
            {
                // A Kind of Magic
                new AlbumSong{AlbumId = 1, SongId = 1},
                new AlbumSong{AlbumId = 1, SongId = 2},
                new AlbumSong{AlbumId = 1, SongId = 3},
                new AlbumSong{AlbumId = 1, SongId = 4},
                new AlbumSong{AlbumId = 1, SongId = 5},
                new AlbumSong{AlbumId = 1, SongId = 6},
                new AlbumSong{AlbumId = 1, SongId = 7},

                // ABBA
                new AlbumSong{AlbumId = 2, SongId = 8},
                new AlbumSong{AlbumId = 2, SongId = 9},
                new AlbumSong{AlbumId = 2, SongId = 10},
                new AlbumSong{AlbumId = 2, SongId = 11},
                new AlbumSong{AlbumId = 2, SongId = 12},
                new AlbumSong{AlbumId = 2, SongId = 13},
                new AlbumSong{AlbumId = 2, SongId = 14},
                
                // The Dark Side of the Moon
                new AlbumSong{AlbumId = 3, SongId = 15},
                new AlbumSong{AlbumId = 3, SongId = 16},
                new AlbumSong{AlbumId = 3, SongId = 17},
                new AlbumSong{AlbumId = 3, SongId = 18},
                new AlbumSong{AlbumId = 3, SongId = 19},
                new AlbumSong{AlbumId = 3, SongId = 20},
                new AlbumSong{AlbumId = 3, SongId = 21},
                new AlbumSong{AlbumId = 3, SongId = 22},
                new AlbumSong{AlbumId = 3, SongId = 23},
                new AlbumSong{AlbumId = 3, SongId = 24},
                
                // Painkiller
                new AlbumSong{AlbumId = 4, SongId = 25},
                new AlbumSong{AlbumId = 4, SongId = 26},
                
                // Boston
                new AlbumSong{AlbumId = 5, SongId = 27},
                new AlbumSong{AlbumId = 5, SongId = 28},
                new AlbumSong{AlbumId = 5, SongId = 29},
                new AlbumSong{AlbumId = 5, SongId = 30},
                new AlbumSong{AlbumId = 5, SongId = 31},
                new AlbumSong{AlbumId = 5, SongId = 32},
                new AlbumSong{AlbumId = 5, SongId = 33},
                new AlbumSong{AlbumId = 5, SongId = 34},
                
                // Aquarium
                new AlbumSong{AlbumId = 6, SongId = 35},
                new AlbumSong{AlbumId = 6, SongId = 36},
                new AlbumSong{AlbumId = 6, SongId = 37},
                new AlbumSong{AlbumId = 6, SongId = 38},
                new AlbumSong{AlbumId = 6, SongId = 39},
                new AlbumSong{AlbumId = 6, SongId = 40},
                new AlbumSong{AlbumId = 6, SongId = 41},
                new AlbumSong{AlbumId = 6, SongId = 42},
                new AlbumSong{AlbumId = 6, SongId = 43},
                new AlbumSong{AlbumId = 6, SongId = 44},
                new AlbumSong{AlbumId = 6, SongId = 45},
                
                // Toto IV
                new AlbumSong{AlbumId = 7, SongId = 46},
                new AlbumSong{AlbumId = 7, SongId = 47},
                new AlbumSong{AlbumId = 7, SongId = 48},
                new AlbumSong{AlbumId = 7, SongId = 49},
                new AlbumSong{AlbumId = 7, SongId = 50},
                new AlbumSong{AlbumId = 7, SongId = 51},
                new AlbumSong{AlbumId = 7, SongId = 52},
                new AlbumSong{AlbumId = 7, SongId = 53},
                new AlbumSong{AlbumId = 7, SongId = 54},
                new AlbumSong{AlbumId = 7, SongId = 55},
                
                // Paranoid
                new AlbumSong{AlbumId = 8, SongId = 56},
                new AlbumSong{AlbumId = 8, SongId = 57},
                new AlbumSong{AlbumId = 8, SongId = 58},
                new AlbumSong{AlbumId = 8, SongId = 59},
                new AlbumSong{AlbumId = 8, SongId = 60},
                new AlbumSong{AlbumId = 8, SongId = 61},
                new AlbumSong{AlbumId = 8, SongId = 62},
                new AlbumSong{AlbumId = 8, SongId = 63},
            };
            context.AlbumSongs.AddRange(albumSongs);

            var artistAlbums = new List<BandAlbum>
            {
                new BandAlbum { BandId = 1, AlbumId = 1},
                new BandAlbum { BandId = 2, AlbumId = 2},
                new BandAlbum { BandId = 3, AlbumId = 3},
                new BandAlbum { BandId = 4, AlbumId = 4},
                new BandAlbum { BandId = 5, AlbumId = 5},
                new BandAlbum { BandId = 6, AlbumId = 6},
                new BandAlbum { BandId = 7, AlbumId = 7},
                new BandAlbum { BandId = 8, AlbumId = 8}
            };
            context.ArtistAlbums.AddRange(artistAlbums);
            context.SaveChanges();
        }
    }
}