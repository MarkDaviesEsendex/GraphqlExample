using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class BandRequest : IRequest<Band>
    {
        public int Id { get; }

        public BandRequest(int id)
        {
            Id = id;
        }
    }
}