using UserApi.Queries;

namespace UserApi.Schema
{
    public class MusicSchema : GraphQL.Types.Schema
    {
        public MusicSchema(MusicQuery query)
        {
            Query = query;
        }
    }
}