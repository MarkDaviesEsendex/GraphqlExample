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
    public class BandResolver
        : IRequestHandler<BandCollectionRequest, List<Band>>
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
    }
}