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