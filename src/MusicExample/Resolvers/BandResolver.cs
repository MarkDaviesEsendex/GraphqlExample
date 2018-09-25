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
    public class BandResolver
        :   IRequestHandler<BandCollectionRequest, List<Band>>,
            IRequestHandler<BandRequest, Band>,
            IRequestHandler<BandByArtistRequest, List<Band>>
    {
        private readonly IRepository<Data.Models.Band> _bandRepository;
        private readonly IMapper _objectMapper;

        public BandResolver(IMapper objectMapper, IRepository<Data.Models.Band> bandRepository)
        {
            _objectMapper = objectMapper;
            _bandRepository = bandRepository;
        }

        public Task<List<Band>> Handle(BandCollectionRequest collectionRequest, CancellationToken cancellationToken)
        {
            var artists = _bandRepository.Get();
            return Task.FromResult(_objectMapper.Map<List<Band>>(artists));
        }

        public Task<Band> Handle(BandRequest request, CancellationToken cancellationToken)
        {
            var artists = _bandRepository.Get().Where(band => band.Id == request.Id);
            return Task.FromResult(_objectMapper.Map<Band>(artists));
        }

        public Task<List<Band>> Handle(BandByArtistRequest request, CancellationToken cancellationToken)
        {
            var artists = _bandRepository.Get();
            return Task.FromResult(_objectMapper.Map<List<Band>>(artists));
        }
    }
}