using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Music.Web.Api.Models;
using Music.Web.Api.Resolvers.Requests;

namespace Music.Web.Api.DataLoaders
{
    public interface IBandDataLoader
    {
        Task<IDictionary<int, Band>> GetBandsByIdAsync(IEnumerable<int> artistIds, CancellationToken cancellationToken);
    }
    
    public class BandDataLoader : IBandDataLoader
    {
        private readonly IMediator _mediator;
        
        public BandDataLoader(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IDictionary<int, Band>> GetBandsByIdAsync(IEnumerable<int> artistIds, CancellationToken cancellationToken)
        {
            var bands = await _mediator.Send(new BandByArtistRequest(artistIds.ToArray()), cancellationToken);
            return bands.ToDictionary(band => band.Id);
        }
    }
}