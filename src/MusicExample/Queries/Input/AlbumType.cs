using System.Collections.Generic;
using GraphQL.Types;
using MediatR;
using Music.Web.Api.Models;
using Music.Web.Api.Queries.Retrieve;
using Music.Web.Api.Resolvers.Requests;

namespace Music.Web.Api.Queries.Input
{
    public class AlbumInputType : InputObjectGraphType<AlbumWithSongs>
    {
        public AlbumInputType(IMediator mediator)
        {
            Field(user => user.Name);
            Field<NonNullGraphType<ListGraphType<StringGraphType>>>()
                .Name("songs");
        }
    }
}