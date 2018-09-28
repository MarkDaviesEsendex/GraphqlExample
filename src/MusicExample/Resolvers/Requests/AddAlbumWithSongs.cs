using System.Collections.Generic;
using MediatR;
using Music.Web.Api.Models;

namespace Music.Web.Api.Resolvers.Requests
{
    public class AddAlbumWithSongs : IRequest<Album>
    {
        public string AlbumName { get; set; }
        public List<string> Songs { get; set; }
    }
}