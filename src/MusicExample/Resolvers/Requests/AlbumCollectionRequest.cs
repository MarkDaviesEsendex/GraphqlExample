﻿using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class AlbumCollectionRequest : IRequest<List<Album>>
    {
    }
}