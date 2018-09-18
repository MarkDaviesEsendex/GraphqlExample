using MediatR;
using GraphQL.Types;
using UserApi.Queries.Retrieve;
using UserApi.Resolvers.Requests;

namespace UserApi.Queries
{
    public class MusicQuery : ObjectGraphType
    {
        public MusicQuery(IMediator mediator)
        {
            Field<ListGraphType<ArtistType>>("artist",
                resolve: context => mediator.Send(new ArtistCollectionRequest()));

            Field<ListGraphType<AlbumType>>("album",
                resolve: context => mediator.Send(new AlbumCollectionRequest()));

            Field<ListGraphType<BandType>>("band",
                resolve: context => mediator.Send(new BandCollectionRequest()));

            Field<ListGraphType<SongType>>("song",
                resolve: context => mediator.Send(new SongCollectionRequest()));
        }
    }
}