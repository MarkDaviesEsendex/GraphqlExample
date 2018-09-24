using GraphQL.Types;
using Music.Web.Api.Models;

namespace Music.Web.Api.Queries.Retrieve
{
    public class AlbumType : ObjectGraphType<Album>
    {
        public AlbumType()
        {
            Field(user => user.Id);
            Field(user => user.Name);
        }
    }
}