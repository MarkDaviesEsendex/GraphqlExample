using GraphQL.Types;
using UserApi.Models;

namespace UserApi.Queries.Retrieve
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