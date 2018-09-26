using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class BandCollectionRequest : IRequest<List<Band>>
    {
        public int NumberOfRecords { get; }

        public int Offset { get; }

        public BandCollectionRequest(int numberOfRecords, int offset)
        {
            NumberOfRecords = numberOfRecords;
            Offset = offset;
        }
    }
}