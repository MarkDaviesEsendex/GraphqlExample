using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Music.Web.Api.Data;
using Music.Web.Api.Data.Models;
using Music.Web.Api.Resolvers.Requests;
using Song = Music.Web.Api.Models.Song;

namespace Music.Web.Api.Resolvers
{
    public class SongResolver
        :   IRequestHandler<SongCollectionRequest, List<Song>>,
            IRequestHandler<SongByAlbumRequest, List<Song>>
    {
        private readonly IMapper _objectMapper;
        private readonly IRepository<Data.Models.Song> _songRepository;
        private readonly IRepository<Data.Models.AlbumSong> _albumSongRepository;

        public SongResolver(IMapper objectMapper, IRepository<Data.Models.Song> songRepository, IRepository<AlbumSong> albumSongRepository)
        {
            _objectMapper = objectMapper;
            _songRepository = songRepository;
            _albumSongRepository = albumSongRepository;
        }

        public Task<List<Song>> Handle(SongCollectionRequest collectionRequest, CancellationToken cancellationToken)
        {
            var songs = _songRepository.Get();
            return Task.FromResult(_objectMapper.Map<List<Song>>(songs));
        }

        public Task<List<Song>> Handle(SongByAlbumRequest request, CancellationToken cancellationToken)
        {
            var songIds = _albumSongRepository.Where(song => song.AlbumId == request.AlbumId)
                .Select(song => song.SongId);
            var songs = _songRepository.Where(song => songIds.Contains(song.Id));
            return Task.FromResult(_objectMapper.Map<List<Song>>(songs));
        }
    }
}