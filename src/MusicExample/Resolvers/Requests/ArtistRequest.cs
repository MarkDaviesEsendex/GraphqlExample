using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class ArtistRequest : IRequest<Artist>
    {
        public int Id { get; }

        public ArtistRequest(int id)
        {
            Id = id;
        }
    }
}