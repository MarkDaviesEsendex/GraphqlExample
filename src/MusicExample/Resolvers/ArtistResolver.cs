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
    public class ArtistResolver
        : IRequestHandler<ArtistCollectionRequest, List<Artist>>
    {
        private readonly IRepository<UserApi.Data.Models.Artist> _artistRepository;
        private readonly IMapper _objectMapper;

        public ArtistResolver(IMapper objectMapper, IRepository<UserApi.Data.Models.Artist> artistRepository)
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