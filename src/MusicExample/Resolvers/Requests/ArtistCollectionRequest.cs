using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class ArtistCollectionRequest : IRequest<List<Artist>>
    {
        public int NumberOfRecords { get; }

        public int Offset { get; }

        public ArtistCollectionRequest(int numberOfRecords, int offset)
        {
            NumberOfRecords = numberOfRecords;
            Offset = offset;
        }
    }
}