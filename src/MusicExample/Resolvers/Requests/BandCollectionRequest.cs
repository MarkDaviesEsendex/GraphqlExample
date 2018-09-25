using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class BandCollectionRequest : IRequest<List<Band>>
    {
    }
    
    public class BandRequest : IRequest<Band>
    {
        public int Id { get; }

        public BandRequest(int id)
        {
            Id = id;
        }
    }
    
    public class BandByArtistRequest : IRequest<List<Band>>
    {
        public int ArtistId { get; }

        public BandByArtistRequest(int artistId)
        {
            ArtistId = artistId;
        }
    }
}