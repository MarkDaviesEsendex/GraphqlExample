using System.Collections.Generic;
using GraphQL.Types;
using MediatR;
using Music.Web.Api.Models;
using Music.Web.Api.Resolvers.Requests;

namespace Music.Web.Api.Queries.Retrieve
{
    public class BandType : ObjectGraphType<Band>
    {
        public BandType(IMediator mediator)
        {
            Field(user => user.Id);
            Field(user => user.Name);
            Field<ListGraphType<ArtistType>, List<Artist>>()
                .Name("members")
                .ResolveAsync(context => mediator.Send(new ArtistByBandRequest(context.Source.Id)));
            
            Field<ListGraphType<AlbumType>, List<Album>>()
                .Name("albums")
                .ResolveAsync(context => mediator.Send(new AlbumByBandRequest(context.Source.Id)));
        }
    }

    
}