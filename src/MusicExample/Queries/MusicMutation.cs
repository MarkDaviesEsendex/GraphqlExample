using GraphQL.Types;
using MediatR;
using Music.Web.Api.Models;
using Music.Web.Api.Queries.Input;
using Music.Web.Api.Queries.Retrieve;
using Music.Web.Api.Resolvers.Requests;

namespace Music.Web.Api.Queries
{
    public class MusicMutation : ObjectGraphType
    {
        public MusicMutation(IMediator mediator)
        {
            Field<AlbumType>()
                .Name("createAlbum")
                .Argument<NonNullGraphType<AlbumInputType>>("album", "The album to add")
                .Resolve(context =>
                {
                    var albumInputType = context.GetArgument<AlbumWithSongs>("album");
                    return mediator.Send(new AddAlbumWithSongs
                    {
                        AlbumName = albumInputType.Name,
                        Songs = albumInputType.Songs
                    });
                });
        }
    }
}