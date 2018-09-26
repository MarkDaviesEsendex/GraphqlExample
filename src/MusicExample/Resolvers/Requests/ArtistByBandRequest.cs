using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class ArtistByBandRequest : IRequest<List<Artist>>
    {
        public int BandId { get; }

        public ArtistByBandRequest(int bandId)
        {
            BandId = bandId;
        }
    }
}