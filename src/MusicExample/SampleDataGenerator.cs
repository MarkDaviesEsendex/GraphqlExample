using System.Collections.Generic;
using System.Linq;
using Music.Web.Api.Data;
using Music.Web.Api.Data.Models;

namespace Music.Web.Api
{
    public class SampleDataGenerator
    {
        private readonly MusicDbContext _dbContext;

        public SampleDataGenerator(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertData()
        {
            var bands = new List<Band>
            {
                new Band {Name = "Queen"},
                new Band {Name = "ABBA"},
                new Band {Name = "Pink Floyd"},
                new Band {Name = "Judas Priest"},
                new Band {Name = "Boston"},
                new Band {Name = "Aqua"},
                new Band {Name = "Toto"},
                new Band {Name = "Black Sabbath"} 
            };
            _dbContext.Bands.AddRange(bands);

            var artists = new List<Artist>
            {
                //Queen
                new Artist {Name = "Freddie Mercury"},
                new Artist {Name = "Brian May"},
                new Artist {Name = "Roger Taylor"},
                new Artist {Name = "John Deacon"},
                
                //Abba
                new Artist {Name = "Agnetha Fältskog"},
                new Artist {Name = "Björn Ulvaeus"},
                new Artist {Name = "Benny Andersson"},
                new Artist {Name = "Anni-Frid Lyngstad"},
                
                // Pink floyd
                new Artist {Name = "Nick Mason"},
                new Artist {Name = "Roger Waters"},
                new Artist {Name = "Richard Wright"},
                new Artist {Name = "Syd Barrett"},
                new Artist {Name = "David Gilmour"},
                
                // Judas Priest
                new Artist {Name = "Ian Hill"},
                new Artist {Name = "Rob Halford"},
                new Artist {Name = "Glenn Tipton"},
                new Artist {Name = "Scott Travis"},
                new Artist {Name = "Richie Faulkner"},
                
                // Boston
                new Artist {Name = "Tom Scholz"},
                new Artist {Name = "Gary Pihl"},
                new Artist {Name = "Curly Smith"},
                new Artist {Name = "Jeff Neal"},
                new Artist {Name = "Tommy DeCarlo"},
                new Artist {Name = "Tracy Ferrie"},
                new Artist {Name = "Beth Cohen"},
                
                // Aqua
                new Artist {Name = "Lene Nystrøm"},
                new Artist {Name = "René Dif"},
                new Artist {Name = "Søren Rasted"},
                
                // Toto
                new Artist {Name = "Steve Lukather"},
                new Artist {Name = "David Paich"},
                new Artist {Name = "Steve Porcaro"},
                new Artist {Name = "Joseph Williams"},
                
                // Sabbath
                new Artist {Name = "Tony Iommi"},
                new Artist {Name = "Geezer Butler"},
                new Artist {Name = "Ozzy Osbourne"},
                
            };
            _dbContext.Artists.AddRange(artists);

            var bandArtists = new List<BandMember>
            {
                //Queen
                new BandMember {BandId = bands[0].Id, ArtistId = artists[0].Id},
                new BandMember {BandId = bands[0].Id, ArtistId = artists[1].Id},
                new BandMember {BandId = bands[0].Id, ArtistId = artists[2].Id},
                new BandMember {BandId = bands[0].Id, ArtistId = artists[3].Id},
                
                // Abba
                new BandMember {BandId = bands[1].Id, ArtistId = artists[4].Id},
                new BandMember {BandId = bands[1].Id, ArtistId = artists[5].Id},
                new BandMember {BandId = bands[1].Id, ArtistId = artists[6].Id},
                new BandMember {BandId = bands[1].Id, ArtistId = artists[7].Id},
                
                // Pink floyd
                new BandMember {BandId = bands[2].Id, ArtistId = artists[8].Id},
                new BandMember {BandId = bands[2].Id, ArtistId = artists[9].Id},
                new BandMember {BandId = bands[2].Id, ArtistId = artists[10].Id},
                new BandMember {BandId = bands[2].Id, ArtistId = artists[11].Id},
                new BandMember {BandId = bands[2].Id, ArtistId = artists[12].Id},
                
                // Judas Priest
                new BandMember {BandId = bands[3].Id, ArtistId = artists[13].Id},
                new BandMember {BandId = bands[3].Id, ArtistId = artists[14].Id},
                new BandMember {BandId = bands[3].Id, ArtistId = artists[15].Id},
                new BandMember {BandId = bands[3].Id, ArtistId = artists[16].Id},
                new BandMember {BandId = bands[3].Id, ArtistId = artists[17].Id},
                
                // Boston
                new BandMember {BandId = bands[4].Id, ArtistId = artists[18].Id},
                new BandMember {BandId = bands[4].Id, ArtistId = artists[19].Id},
                new BandMember {BandId = bands[4].Id, ArtistId = artists[20].Id},
                new BandMember {BandId = bands[4].Id, ArtistId = artists[21].Id},
                new BandMember {BandId = bands[4].Id, ArtistId = artists[22].Id},
                new BandMember {BandId = bands[4].Id, ArtistId = artists[23].Id},
                new BandMember {BandId = bands[4].Id, ArtistId = artists[24].Id},
                
                // Aqua
                new BandMember {BandId = bands[5].Id, ArtistId = artists[25].Id},
                new BandMember {BandId = bands[5].Id, ArtistId = artists[26].Id},
                new BandMember {BandId = bands[5].Id, ArtistId = artists[27].Id},
                
                // Toto
                new BandMember {BandId = bands[6].Id, ArtistId = artists[28].Id},
                new BandMember {BandId = bands[6].Id, ArtistId = artists[29].Id},
                new BandMember {BandId = bands[6].Id, ArtistId = artists[30].Id},
                new BandMember {BandId = bands[6].Id, ArtistId = artists[31].Id},
                
                // Sabbath
                new BandMember {BandId = bands[7].Id, ArtistId = artists[32].Id},
                new BandMember {BandId = bands[7].Id, ArtistId = artists[33].Id},
                new BandMember {BandId = bands[7].Id, ArtistId = artists[34].Id},
            };
            _dbContext.BandArtists.AddRange(bandArtists);

            var albums = new List<Album>
            {
                new Album { Name = "A Kind of Magic"},
                new Album { Name = "ABBA"},
                new Album { Name = "The Dark Side of the Moon"},
                new Album { Name = "Painkiller"},
                new Album { Name = "Boston"},
                new Album { Name = "Aquarium"},
                new Album { Name = "Toto IV"},
                new Album { Name = "Paranoid"},
            };
            _dbContext.Albums.AddRange(albums);
            
            var songs = new List<Song>
            {
                // A Kind of Magic
                new Song{ Name = "One Vision"},
                new Song{ Name = "A Kind of Magic"},
                new Song{ Name = "Princes of the Universe"},
                new Song{ Name = "One Year of Love"},
                new Song{ Name = "Friends Will Be Friends"},
                new Song{ Name = "Pain Is So Close to Pleasure"},
                new Song{ Name = "Who Wants to Live Forever"},
                
                // ABBA
                new Song{Name = "So Long"},
                new Song{Name = "I've Been Waiting for You"},
                new Song{Name = "I Do, I Do, I Do, I Do, I Do"},
                new Song{Name = "Bang-A-Boomerang"},
                new Song{Name = "SOS"},
                new Song{Name = "Mamma Mia"},
                new Song{Name = "Rock Me"},
                
                // The Dark Side of the Moon
                new Song{Name = "Speak to Me"},
                new Song{Name = "Breathe"},
                new Song{Name = "On the Run"},
                new Song{Name = "Time"},
                new Song{Name = "The Great Gig in the Sky"},
                new Song{Name = "Money"},
                new Song{Name = "Us and Them"},
                new Song{Name = "Any Colour You Like"},
                new Song{Name = "Brain Damage"},
                new Song{Name = "Eclipse"},
                
                // Painkiller
                new Song{Name = "Painkiller"},
                new Song{Name = "A Touch of Evil"},
                
                // Boston
                new Song{Name = "More Than a Feeling"},
                new Song{Name = "Peace of Mind"},
                new Song{Name = "Foreplay / Long Time"},
                new Song{Name = "Rock & Roll Band"},
                new Song{Name = "Smokin'"},
                new Song{Name = "Hitch a Ride"},
                new Song{Name = "Something About You"},
                new Song{Name = "Let Me Take You Home Tonight"},
              
                // Aquarium
                new Song{Name = "Happy Boys & Girls"},
                new Song{Name = "My Oh My"},
                new Song{Name = "Barbie Girl"},
                new Song{Name = "Good Morning Sunshine"},
                new Song{Name = "Doctor Jones"},
                new Song{Name = "Heat Of The Night"},
                new Song{Name = "Be A Man"},
                new Song{Name = "Lollipop (Candyman)"},
                new Song{Name = "Roses Are Red"},
                new Song{Name = "Turn Back Time"},
                new Song{Name = "Calling You"},
                
                // Toto IV
                new Song{Name = "Rosanna"},
                new Song{Name = "Make Believe"},
                new Song{Name = "I Won't Hold You Back"},
                new Song{Name = "Good for You"},
                new Song{Name = "It's a Feeling"},
                new Song{Name = "Afraid of Love"},
                new Song{Name = "Lovers in the Night"},
                new Song{Name = "We Made It"},
                new Song{Name = "Waiting for Your Love"},
                new Song{Name = "Africa"},
                
                // Paranoid
                new Song{Name = "War Pigs"},
                new Song{Name = "Paranoid"},
                new Song{Name = "Planet Caravan"},
                new Song{Name = "Iron Man"},
                new Song{Name = "Electric Funeral"},
                new Song{Name = "Hand of Doom"},
                new Song{Name = "Rat Salad"},
                new Song{Name = "Fairies Wear Boots"},
            };
            _dbContext.Songs.AddRange(songs);

            var albumSongs = new List<AlbumSong>
            {
                // A Kind of Magic
                new AlbumSong{AlbumId = albums[0].Id, SongId = songs[0].Id},
                new AlbumSong{AlbumId = albums[0].Id, SongId = songs[1].Id},
                new AlbumSong{AlbumId = albums[0].Id, SongId = songs[2].Id},
                new AlbumSong{AlbumId = albums[0].Id, SongId = songs[3].Id},
                new AlbumSong{AlbumId = albums[0].Id, SongId = songs[4].Id},
                new AlbumSong{AlbumId = albums[0].Id, SongId = songs[5].Id},
                new AlbumSong{AlbumId = albums[0].Id, SongId = songs[6].Id},

                // ABBA
                new AlbumSong{AlbumId = albums[1].Id, SongId = songs[7].Id},
                new AlbumSong{AlbumId = albums[1].Id, SongId = songs[8].Id},
                new AlbumSong{AlbumId = albums[1].Id, SongId = songs[9].Id},
                new AlbumSong{AlbumId = albums[1].Id, SongId = songs[10].Id},
                new AlbumSong{AlbumId = albums[1].Id, SongId = songs[11].Id},
                new AlbumSong{AlbumId = albums[1].Id, SongId = songs[12].Id},
                new AlbumSong{AlbumId = albums[1].Id, SongId = songs[13].Id},
                
                // The Dark Side of the Moon
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[14].Id},
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[15].Id},
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[16].Id},
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[17].Id},
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[18].Id},
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[19].Id},
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[20].Id},
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[21].Id},
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[22].Id},
                new AlbumSong{AlbumId = albums[2].Id, SongId = songs[23].Id},
                
                // Painkiller
                new AlbumSong{AlbumId = albums[3].Id, SongId = songs[24].Id},
                new AlbumSong{AlbumId = albums[3].Id, SongId = songs[25].Id},
                
                // Boston
                new AlbumSong{AlbumId = albums[4].Id, SongId = songs[26].Id},
                new AlbumSong{AlbumId = albums[4].Id, SongId = songs[27].Id},
                new AlbumSong{AlbumId = albums[4].Id, SongId = songs[28].Id},
                new AlbumSong{AlbumId = albums[4].Id, SongId = songs[29].Id},
                new AlbumSong{AlbumId = albums[4].Id, SongId = songs[30].Id},
                new AlbumSong{AlbumId = albums[4].Id, SongId = songs[31].Id},
                new AlbumSong{AlbumId = albums[4].Id, SongId = songs[32].Id},
                new AlbumSong{AlbumId = albums[4].Id, SongId = songs[33].Id},
                
                // Aquarium
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[34].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[35].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[36].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[37].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[38].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[39].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[40].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[41].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[42].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[43].Id},
                new AlbumSong{AlbumId = albums[5].Id, SongId = songs[44].Id},
                
                // Toto IV
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[45].Id},
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[46].Id},
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[47].Id},
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[48].Id},
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[49].Id},
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[50].Id},
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[51].Id},
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[52].Id},
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[53].Id},
                new AlbumSong{AlbumId = albums[6].Id, SongId = songs[54].Id},
                
                // Paranoid
                new AlbumSong{AlbumId = albums[7].Id, SongId = songs[55].Id},
                new AlbumSong{AlbumId = albums[7].Id, SongId = songs[56].Id},
                new AlbumSong{AlbumId = albums[7].Id, SongId = songs[57].Id},
                new AlbumSong{AlbumId = albums[7].Id, SongId = songs[58].Id},
                new AlbumSong{AlbumId = albums[7].Id, SongId = songs[59].Id},
                new AlbumSong{AlbumId = albums[7].Id, SongId = songs[60].Id},
                new AlbumSong{AlbumId = albums[7].Id, SongId = songs[61].Id},
                new AlbumSong{AlbumId = albums[7].Id, SongId = songs[62].Id},
            };
            _dbContext.AlbumSongs.AddRange(albumSongs);

            var artistAlbums = new List<BandAlbum>
            {
                new BandAlbum { BandId = bands[0].Id, AlbumId = albums[0].Id},
                new BandAlbum { BandId = bands[1].Id, AlbumId = albums[1].Id},
                new BandAlbum { BandId = bands[2].Id, AlbumId = albums[2].Id},
                new BandAlbum { BandId = bands[3].Id, AlbumId = albums[3].Id},
                new BandAlbum { BandId = bands[4].Id, AlbumId = albums[4].Id},
                new BandAlbum { BandId = bands[5].Id, AlbumId = albums[5].Id},
                new BandAlbum { BandId = bands[6].Id, AlbumId = albums[6].Id},
                new BandAlbum { BandId = bands[7].Id, AlbumId = albums[7].Id}
            };
            _dbContext.ArtistAlbums.AddRange(artistAlbums);
            _dbContext.SaveChanges();
        }
    }
}