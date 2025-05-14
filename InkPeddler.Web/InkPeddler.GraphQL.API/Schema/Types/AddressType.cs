using HotChocolate.Types;
using InkPeddler.GraphQL.API.Models;


namespace InkPeddler.GraphQL.API.Schema.Types
{
    public class AddressType : ObjectType<Address>
    {
        protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
        {
            base.Configure(descriptor);

        }
    }
}