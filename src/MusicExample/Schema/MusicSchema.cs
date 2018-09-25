using GraphQL;
using Music.Web.Api.Queries;

namespace Music.Web.Api.Schema
{
    public class MusicSchema : GraphQL.Types.Schema
    {
        public MusicSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<MusicQuery>();
        }
    }
}