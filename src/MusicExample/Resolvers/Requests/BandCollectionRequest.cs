using System.Collections.Generic;
using MediatR;
using UserApi.Models;

namespace UserApi.Resolvers.Requests
{
    public class BandCollectionRequest : IRequest<List<Band>>
    {
    }
}