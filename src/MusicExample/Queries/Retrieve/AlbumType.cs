using System.Collections.Generic;
using GraphQL.Types;
using MediatR;
using Music.Web.Api.Models;
using Music.Web.Api.Resolvers.Requests;

namespace Music.Web.Api.Queries.Retrieve
{
    public class AlbumType : ObjectGraphType<Album>
    {
        public AlbumType(IMediator mediator)
        {
            Field(user => user.Id);
            Field(user => user.Name);
            Field<ListGraphType<SongType>, List<Song>>()
                .Name("Songs")
                .ResolveAsync(context => mediator.Send(new SongByAlbumRequest(context.Source.Id)));
        }
    }
}