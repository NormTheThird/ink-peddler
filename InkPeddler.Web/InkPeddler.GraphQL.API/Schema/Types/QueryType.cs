using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace InkPeddler.GraphQL.API.Schema.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetAccounts(default))
                .Type<NonNullType<ListType<NonNullType<AccountType>>>>();

            descriptor.Field(q => q.GetAccountsPaging(default))
               .Type<NonNullType<ListType<NonNullType<AccountType>>>>()
               .UsePaging<AccountType>()
               .UseFiltering();   

            descriptor.Field(q => q.GetAccount(default, default))
               .Authorize()
               .Argument("id", a => a.Type<NonNullType<IdType>>());
        }
    }
}
