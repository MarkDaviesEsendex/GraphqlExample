using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class SongByAlbumRequest : IRequest<List<Song>>
    {
        public int AlbumId { get; }

        public SongByAlbumRequest(int albumId)
        {
            AlbumId = albumId;
        }
    }
}