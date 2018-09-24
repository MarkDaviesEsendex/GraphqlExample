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
            Field<ListGraphType<ArtistType>>("artists",
                arguments: new QueryArguments
                {
                    new QueryArgument<IntGraphType> { Name = "first"},
                    new QueryArgument<IntGraphType> { Name = "offset"}
                },
                resolve: context => mediator.Send(new ArtistCollectionRequest()));
            
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
}