using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Music.Web.Api.Data;
using Music.Web.Api.Models;
using Music.Web.Api.Resolvers.Requests;
using UserApi.Data;

namespace Music.Web.Api.Resolvers
{
    public class AlbumResolver
        : IRequestHandler<AlbumCollectionRequest, List<Album>>
    {
        private readonly IRepository<Data.Models.Album> _albumRepository;
        private readonly IMapper _objectMapper;

        public AlbumResolver(IMapper objectMapper, IRepository<Data.Models.Album> albumRepository)
        {
            _objectMapper = objectMapper;
            _albumRepository = albumRepository;
        }

        public Task<List<Album>> Handle(AlbumCollectionRequest request, CancellationToken cancellationToken)
        {
            var albums = _albumRepository.Get();
            return Task.FromResult(_objectMapper.Map<List<Album>>(albums));
        }
    }
}