using GraphQL.Types;
using MediatR;
using Music.Web.Api.Queries.Retrieve;
using Music.Web.Api.Resolvers.Requests;

namespace Music.Web.Api.Queries
{
    public class MusicQuery : ObjectGraphType
    {
        public MusicQuery(IMediator mediator)
        {
            Field<ListGraphType<ArtistType>>()
                .Name("artists")
                .Argument<NonNullGraphType<IntGraphType>>("first", "Used to select specified number of records")
                .Argument<NonNullGraphType<IntGraphType>>("offset", "Zero indexed offset for selector")
                .Resolve(context =>
                    mediator.Send(new ArtistCollectionRequest(context.GetArgument<int>("first"), context.GetArgument<int>("offset"))));

            Field<ArtistType>()
                .Name("artist")
                .Argument<NonNullGraphType<IntGraphType>>("id", "Id of the artist")
                .Resolve(context => mediator.Send(new ArtistRequest(context.GetArgument<int>("id"))));
            
            Field<ListGraphType<AlbumType>>()
                .Name("albums")
                .Argument<NonNullGraphType<IntGraphType>>("first", "Used to select specified number of records")
                .Argument<NonNullGraphType<IntGraphType>>("offset", "Zero indexed offset for selector")
                .Resolve(context => mediator.Send(new AlbumCollectionRequest()));
            
            Field<ListGraphType<BandType>>()
                .Name("bands")
                .Argument<NonNullGraphType<IntGraphType>>("first", "Used to select specified number of records")
                .Argument<NonNullGraphType<IntGraphType>>("offset", "Zero indexed offset for selector")
                .Resolve(context => mediator.Send(new BandCollectionRequest()));
            
            Field<ListGraphType<SongType>>()
                .Name("songs")
                .Argument<NonNullGraphType<IntGraphType>>("first", "Used to select specified number of records")
                .Argument<NonNullGraphType<IntGraphType>>("offset", "Zero indexed offset for selector")
                .Resolve(context => mediator.Send(new SongCollectionRequest()));
        }
    }
}