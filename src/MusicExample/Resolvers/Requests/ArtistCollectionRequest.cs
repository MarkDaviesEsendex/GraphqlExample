using System.Collections.Generic;
using MediatR;
using UserApi.Models;

namespace UserApi.Resolvers.Requests
{
    public class ArtistCollectionRequest : IRequest<List<Artist>>
    {
    }
}