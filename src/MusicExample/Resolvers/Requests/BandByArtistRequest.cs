using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class BandByArtistRequest : IRequest<List<Band>>
    {
        public int[] ArtistId { get; }

        public BandByArtistRequest(int[] artistId)
        {
            ArtistId = artistId;
        }
    }
}