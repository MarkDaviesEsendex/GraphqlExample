using GraphQL.DataLoader;
using GraphQL.Types;
using Music.Web.Api.DataLoaders;
using Music.Web.Api.Models;

namespace Music.Web.Api.Queries.Retrieve
{
    public class ArtistType : ObjectGraphType<Artist>
    {
        public ArtistType(IDataLoaderContextAccessor accessor, IBandDataLoader bandDataLoader)
        {
            Field(user => user.Id);
            Field(user => user.Name);
            Field<BandType, Band>()
                .Name("Bands")
                .Argument<IntGraphType>("first", "")
                .Argument<IntGraphType>("offset", "")
                .ResolveAsync(context =>
                {
                    var loader = accessor.Context.GetOrAddBatchLoader<int, Band>("GetBandByArtist", bandDataLoader.GetBandsByIdAsync);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}