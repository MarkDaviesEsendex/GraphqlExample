using GraphQL.Types;
using UserApi.Models;

namespace UserApi.Queries.Retrieve
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