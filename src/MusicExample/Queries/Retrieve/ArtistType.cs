using GraphQL.Types;
using Music.Web.Api.Models;

namespace Music.Web.Api.Queries.Retrieve
{
    public class ArtistType : ObjectGraphType<Artist>
    {
        public ArtistType()
        {
            Field(user => user.Id);
            Field(user => user.Name);
        }
    }
}