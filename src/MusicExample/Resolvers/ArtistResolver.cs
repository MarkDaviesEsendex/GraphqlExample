using MediatR;
using AutoMapper;
using UserApi.Data;
using UserApi.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using UserApi.Resolvers.Requests;

namespace UserApi.Resolvers
{
    public class ArtistResolver
        : IRequestHandler<ArtistCollectionRequest, List<Artist>>
    {
        private readonly IMapper _objectMapper;
        private readonly IRepository<Data.Models.Artist> _artistRepository;

        public ArtistResolver(IMapper objectMapper, IRepository<Data.Models.Artist> artistRepository)
        {
            _objectMapper = objectMapper;
            _artistRepository = artistRepository;
        }

        public Task<List<Artist>> Handle(ArtistCollectionRequest collectionRequest, CancellationToken cancellationToken)
        {
            var artists = _artistRepository.Get();
            return Task.FromResult(_objectMapper.Map<List<Artist>>(artists));
        }
    }
}