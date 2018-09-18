using GraphQL.Types;
using UserApi.Models;

namespace UserApi.Queries.Retrieve
{
    public class SongType : ObjectGraphType<Song>
    {
        public SongType()
        {
            Field(user => user.Id);
            Field(user => user.Name);
        }
    }
}