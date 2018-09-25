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
                new Band {Id = 8, Name = "Toto"},
                new Band {Id = 9, Name = "Ozzy Osbourne"} 
            };
            context.Bands.AddRange(bands);

            var artists = new List<Artist>
            {
                new Artist {Id = 1, Name = "Freddie Mercury"},
                new Artist {Id = 2, Name = "Brian May"}
            };
            context.Artists.AddRange(artists);

            var bandArtists = new List<BandMember>
            {
                new BandMember {BandId = 1, ArtistId = 1},
                new BandMember {BandId = 1, ArtistId = 2}
            };
            context.BandArtists.AddRange(bandArtists);

            var songs = new List<Song>
            {
                new Song {Id = 1, Name = "Killer Queen"}
            };

            context.Songs.AddRange(songs);

            context.SaveChanges();
        }
    }
}