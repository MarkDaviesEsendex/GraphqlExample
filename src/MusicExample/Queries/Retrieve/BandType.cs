using GraphQL.Types;
using Music.Web.Api.Models;

namespace Music.Web.Api.Queries.Retrieve
{
    public class BandType : ObjectGraphType<Band>
    {
        public BandType()
        {
            Field(user => user.Id);
            Field(user => user.Name);
        }
    }
}