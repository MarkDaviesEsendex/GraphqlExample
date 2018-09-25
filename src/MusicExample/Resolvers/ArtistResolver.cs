using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Music.Web.Api.Data;
using Music.Web.Api.Models;
using Music.Web.Api.Resolvers.Requests;

namespace Music.Web.Api.Resolvers
{
    public class ArtistResolver
        : IRequestHandler<ArtistCollectionRequest, List<Artist>>,
          IRequestHandler<ArtistRequest, Artist>
    {
        private readonly IRepository<Data.Models.Artist> _artistRepository;
        private readonly IMapper _objectMapper;

        public ArtistResolver(IMapper objectMapper, IRepository<Data.Models.Artist> artistRepository)
        {
            _objectMapper = objectMapper;
            _artistRepository = artistRepository;
        }

        public Task<List<Artist>> Handle(ArtistCollectionRequest collectionRequest, CancellationToken cancellationToken)
        {
            var artists = _artistRepository.Get()
                .Skip(collectionRequest.Offset)
                .Take(collectionRequest.NumberOfRecords);
            
            return Task.FromResult(_objectMapper.Map<List<Artist>>(artists));
        }

        public Task<Artist> Handle(ArtistRequest request, CancellationToken cancellationToken)
        {
            var artists = _artistRepository.Get()
                .First(artist => artist.Id == request.Id);
            return Task.FromResult(_objectMapper.Map<Artist>(artists));
        }
    }
}