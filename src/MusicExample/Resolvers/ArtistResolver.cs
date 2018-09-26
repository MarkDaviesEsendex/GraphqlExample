using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Music.Web.Api.Data;
using Music.Web.Api.Data.Models;
using Music.Web.Api.Resolvers.Requests;
using Artist = Music.Web.Api.Models.Artist;

namespace Music.Web.Api.Resolvers
{
    public class ArtistResolver
        : IRequestHandler<ArtistCollectionRequest, List<Artist>>,
          IRequestHandler<ArtistRequest, Artist>,
          IRequestHandler<ArtistByBandRequest, List<Artist>>
    {
        private readonly IMapper _objectMapper;
        private readonly IRepository<Data.Models.Artist> _artistRepository;
        private readonly IRepository<BandMember> _bandMemberRepository;

        public ArtistResolver(IMapper objectMapper, IRepository<Data.Models.Artist> artistRepository, IRepository<BandMember> bandMemberRepository)
        {
            _objectMapper = objectMapper;
            _artistRepository = artistRepository;
            _bandMemberRepository = bandMemberRepository;
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
            var artists = _artistRepository.Where(artist => artist.Id == request.Id)
                .First();
            return Task.FromResult(_objectMapper.Map<Artist>(artists));
        }

        public Task<List<Artist>> Handle(ArtistByBandRequest request, CancellationToken cancellationToken)
        {
            var bandMembers = _bandMemberRepository.Where(member => member.BandId == request.BandId)
                .Select(member => member.ArtistId);
            var artists = _artistRepository.Where(artist => bandMembers.Contains(artist.Id));
            return Task.FromResult(_objectMapper.Map<List<Artist>>(artists));
        }
    }
}