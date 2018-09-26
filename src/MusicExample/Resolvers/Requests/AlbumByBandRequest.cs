using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class AlbumByBandRequest : IRequest<List<Album>>
    {
        public int BandId { get; }
        
        public AlbumByBandRequest(int bandId)
        {
            BandId = bandId;
        }
    }
}