using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Music.Web.Api.Data;
using Music.Web.Api.Data.Models;
using Music.Web.Api.Resolvers.Requests;
using Album = Music.Web.Api.Models.Album;

namespace Music.Web.Api.Resolvers
{
    public class AlbumResolver
        :   IRequestHandler<AlbumCollectionRequest, List<Album>>,
            IRequestHandler<AlbumByBandRequest, List<Album>>,
            IRequestHandler<AddAlbumWithSongs, Album>
    {
        private readonly IMapper _objectMapper;
        private readonly IRepository<Data.Models.Album> _albumRepository;
        private readonly IRepository<BandAlbum> _bandAlbumRepository;
        private readonly IRepository<Song> _songRepository;
        private readonly IRepository<AlbumSong> _albumSongRepository;

        public AlbumResolver(IMapper objectMapper, IRepository<Data.Models.Album> albumRepository, IRepository<BandAlbum> bandAlbumRepository, IRepository<Song> songRepository, IRepository<AlbumSong> albumSongRepository)
        {
            _objectMapper = objectMapper;
            _albumRepository = albumRepository;
            _bandAlbumRepository = bandAlbumRepository;
            _songRepository = songRepository;
            _albumSongRepository = albumSongRepository;
        }

        public Task<List<Album>> Handle(AlbumCollectionRequest request, CancellationToken cancellationToken)
        {
            var albums = _albumRepository.Get();
            return Task.FromResult(_objectMapper.Map<List<Album>>(albums));
        }

        public Task<List<Album>> Handle(AlbumByBandRequest request, CancellationToken cancellationToken)
        {
            var albumIds = _bandAlbumRepository.Where(album => album.BandId == request.BandId)
                .Select(album => album.AlbumId);
            var albums = _albumRepository.Where(album => albumIds.Contains(album.Id));
            return Task.FromResult(_objectMapper.Map<List<Album>>(albums));
        }

        public Task<Album> Handle(AddAlbumWithSongs request, CancellationToken cancellationToken)
        {
            var album = _albumRepository.Save(new Data.Models.Album {Name = request.AlbumName});
            var songs = _songRepository.Save(request.Songs.Select(sng => new Song {Name = sng}).ToList());
            
            foreach (var song in songs)
            {
                _albumSongRepository.Save(new AlbumSong {AlbumId = album.Id, SongId = song.Id});
            }
            
            return Task.FromResult(_objectMapper.Map<Album>(album));
        }
    }
}