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

            Field<ArtistType>("artist",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> {Name = "id"}
                },
                resolve: context =>
                    mediator.Send(new ArtistRequest(context.GetArgument<int>("id"))));
            
            Field<ListGraphType<AlbumType>>("albums",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> { Name = "first"},
                    new QueryArgument<IntGraphType> { Name = "offset"}
                },
                resolve: context => mediator.Send(new AlbumCollectionRequest()));

            Field<ListGraphType<BandType>>("bands",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> { Name = "first"},
                    new QueryArgument<IntGraphType> { Name = "offset"}
                },
                resolve: context => mediator.Send(new BandCollectionRequest()));

            Field<ListGraphType<SongType>>("songs",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> { Name = "first"},
                    new QueryArgument<IntGraphType> { Name = "offset"}
                },
                resolve: context => mediator.Send(new SongCollectionRequest()));
        }
    }
    
    public class ArtistQuery : ObjectGraphType
    {
        public ArtistQuery(IMediator mediator)
        {
            
        }
    }
}