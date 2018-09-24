using Music.Web.Api.Queries;

namespace Music.Web.Api.Schema
{
    public class MusicSchema : GraphQL.Types.Schema
    {
        public MusicSchema(MusicQuery query)
        {
            Query = query;
        }
    }
}