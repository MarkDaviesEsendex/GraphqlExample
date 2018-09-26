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
            IRequestHandler<AlbumByBandRequest, List<Album>>
    {
        private readonly IMapper _objectMapper;
        private readonly IRepository<Data.Models.Album> _albumRepository;
        private readonly IRepository<BandAlbum> _bandAlbumRepository;

        public AlbumResolver(IMapper objectMapper, IRepository<Data.Models.Album> albumRepository, IRepository<BandAlbum> bandAlbumRepository)
        {
            _objectMapper = objectMapper;
            _albumRepository = albumRepository;
            _bandAlbumRepository = bandAlbumRepository;
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
    }
}