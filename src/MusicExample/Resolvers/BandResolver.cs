using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Music.Web.Api.Data;
using Music.Web.Api.Data.Models;
using Music.Web.Api.Resolvers.Requests;
using Band = Music.Web.Api.Models.Band;

namespace Music.Web.Api.Resolvers
{
    public class BandResolver
        :   IRequestHandler<BandCollectionRequest, List<Band>>,
            IRequestHandler<BandRequest, Band>,
            IRequestHandler<BandByArtistRequest, List<Band>>
    {
        private readonly IRepository<Data.Models.Band> _bandRepository;
        private readonly IRepository<BandMember> _bandMemberRepository;
        private readonly IMapper _objectMapper;

        public BandResolver(IMapper objectMapper, IRepository<Data.Models.Band> bandRepository, IRepository<BandMember> bandMemberRepository)
        {
            _objectMapper = objectMapper;
            _bandRepository = bandRepository;
            _bandMemberRepository = bandMemberRepository;
        }

        public Task<List<Band>> Handle(BandCollectionRequest collectionRequest, CancellationToken cancellationToken)
        {
            var bands = _bandRepository.Get();
            return Task.FromResult(_objectMapper.Map<List<Band>>(bands));
        }

        public Task<Band> Handle(BandRequest request, CancellationToken cancellationToken)
        {
            var bands = _bandRepository.Where(band => band.Id == request.Id);
            return Task.FromResult(_objectMapper.Map<Band>(bands));
        }

        public Task<List<Band>> Handle(BandByArtistRequest request, CancellationToken cancellationToken)
        {
            var bandIds = _bandMemberRepository.Where(member => request.ArtistId.Any(i => i == member.ArtistId))
                .Select(member => member.BandId);
            
            var bands = _bandRepository.Where(band => bandIds.Any(i => i == band.Id));
            return Task.FromResult(_objectMapper.Map<List<Band>>(bands));
        }
    }
}