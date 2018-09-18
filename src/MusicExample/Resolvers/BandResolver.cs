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
    public class BandResolver
        : IRequestHandler<BandCollectionRequest, List<Band>>
    {
        private readonly IMapper _objectMapper;
        private readonly IRepository<Data.Models.Band> _bandRepository;

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