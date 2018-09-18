using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserApi.Data;
using UserApi.Models;
using UserApi.Resolvers.Requests;

namespace UserApi.Resolvers
{
    public class AlbumResolver
        : IRequestHandler<AlbumCollectionRequest, List<Album>>
    {
        private readonly IMapper _objectMapper;
        private readonly IRepository<Data.Models.Album> _albumRepository;

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