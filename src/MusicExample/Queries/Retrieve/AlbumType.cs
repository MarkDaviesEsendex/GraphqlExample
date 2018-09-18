using GraphQL.Types;
using UserApi.Models;

namespace UserApi.Queries.Retrieve
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