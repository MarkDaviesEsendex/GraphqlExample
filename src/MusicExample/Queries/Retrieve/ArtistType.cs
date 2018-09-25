using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using MediatR;
using Music.Web.Api.Models;
using Music.Web.Api.Resolvers.Requests;

namespace Music.Web.Api.Queries.Retrieve
{
    public class ArtistType : ObjectGraphType<Artist>
    {
        public ArtistType(IDataLoaderContextAccessor accessor, IBandStore bandStore)
        {
            Field(user => user.Id);
            Field(user => user.Name);
            Field<BandType, Band>()
                .Name("Bands")
                .ResolveAsync(context =>
                {
                    var loader = accessor.Context.GetOrAddBatchLoader<int, Band>("GetBandByArtist", bandStore.GetBandsByIdAsync);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }

    public interface IBandStore
    {
        Task<IDictionary<int, Band>> GetBandsByIdAsync(IEnumerable<int> userIds, CancellationToken cancellationToken);
    }
    
    public class BandStore : IBandStore
    {
        private readonly IMediator _mediator;
        public BandStore(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IDictionary<int, Band>> GetBandsByIdAsync(IEnumerable<int> userIds, CancellationToken cancellationToken)
        {
            var bands = await _mediator.Send(new BandByArtistRequest(userIds.First()), cancellationToken);
            return bands.ToDictionary(band => band.Id);
        }
    }
}