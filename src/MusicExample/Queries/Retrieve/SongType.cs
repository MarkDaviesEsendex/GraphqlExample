using GraphQL.Types;
using Music.Web.Api.Models;

namespace Music.Web.Api.Queries.Retrieve
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