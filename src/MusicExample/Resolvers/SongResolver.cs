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
    public class SongResolver
        : IRequestHandler<SongCollectionRequest, List<Song>>
    {
        private readonly IMapper _objectMapper;
        private readonly IRepository<Data.Models.Song> _songRepository;

        public SongResolver(IMapper objectMapper, IRepository<Data.Models.Song> songRepository)
        {
            _objectMapper = objectMapper;
            _songRepository = songRepository;
        }

        public Task<List<Song>> Handle(SongCollectionRequest collectionRequest, CancellationToken cancellationToken)
        {
            var artists = _songRepository.Get();
            return Task.FromResult(_objectMapper.Map<List<Song>>(artists));
        }
    }
}